﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Fooxboy.MusicX.Core;
using Fooxboy.MusicX.Core.Interfaces;
using Fooxboy.MusicX.Core.Models;
using Fooxboy.MusicX.Uwp.Services;

namespace Fooxboy.MusicX.Uwp.ViewModels
{
    public class SearchViewModel:BaseViewModel
    {

        public bool VisibleLoading { get; set; }
        public bool VisibleContent { get; set; }

        public ObservableCollection<IBlock> Blocks { get; set; }

        private Api _api;
        private NotificationService _notificationService;
        public SearchViewModel(Api api, NotificationService notification)
        {
            _api = api;
            _notificationService = notification;
            Blocks = new ObservableCollection<IBlock>();
            VisibleLoading = true;
            VisibleContent = false;
        }

        public async Task StartLoading(string query)
        {
            try
            {
                var results = await _api.VKontakte.Music.Search.GetResultsAsync(query);

                var emptyBlock = results.Single(b => b.Source == "search_suggestions");

                results.Remove(emptyBlock);

                VisibleContent = true;
                VisibleLoading = false;
                Changed("VisibleContent");
                Changed("VisibleLoading");

                foreach (var result in results)
                {
                    Blocks.Add(result);
                }
            }
            catch (FlurlHttpException)
            {
                _notificationService.CreateNotification("Ошибка сети", "Произошла ошибка подключения к сети.",
                    "Попробовать ещё раз", "Закрыть", new RelayCommand(
                        async () => { await this.StartLoading(query); }), new RelayCommand(() => { }));
            }
            catch (Exception e)
            {
                _notificationService.CreateNotification("Невозможно получить результаты поиска.", $"Ошибка: {e.Message}");
            }

        }

    }
}
