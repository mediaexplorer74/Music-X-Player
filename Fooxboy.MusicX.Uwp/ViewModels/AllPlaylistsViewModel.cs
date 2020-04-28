﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using Fooxboy.MusicX.Core;
using Fooxboy.MusicX.Uwp.Models;
using Fooxboy.MusicX.Uwp.Services;

namespace Fooxboy.MusicX.Uwp.ViewModels
{
    public class AllPlaylistsViewModel:BaseViewModel
    {
        private NotificationService _notify;
        public AllPlaylistsViewModel(IContainer container)
        {
            _container = container;
            Albums = new ObservableCollection<Album>();
            _notify = _container.Resolve<NotificationService>();
        }

        public ObservableCollection<Album> Albums { get; set; }

        public string TitlePage { get; set; }

        private int _maxAlbums;
        private uint _currentCountAlbums;
        private bool _hasLoadMore;
        private bool _isLoading;
        private IContainer _container;

        private AllPlaylistsModel _model;
        private LoadingService loadingService;

        private AlbumLoaderService loader;

        public async Task StartLoading(AllPlaylistsModel model)
        {
            loader = model.AlbumLoader;
            _isLoading = false;
            _hasLoadMore = true;
            _model = model;
            TitlePage = model.TitlePage;
            Changed("TitlePage");
            loadingService = _container.Resolve<LoadingService>();
            loadingService.Change(true);
            var api = _container.Resolve<Api>();

            await Load();
            Changed("Albums");

        }

        private async Task Load()
        {
            try
            {
                _isLoading = true;
                if (_model.TypeViewPlaylist == AllPlaylistsModel.TypeView.UserAlbum)
                {

                    var albums = await loader.GetLibraryAlbums(_currentCountAlbums, 20);
                    if (albums.Count == 0)
                    {
                        _hasLoadMore = false;
                        return;
                    }

                    foreach (var album in albums)
                    {
                        Albums.Add(album);
                    }

                    _currentCountAlbums += Convert.ToUInt32(albums.Count);

                    loadingService.Change(false);
                }
                else if (_model.TypeViewPlaylist == AllPlaylistsModel.TypeView.ArtistAlbum)
                {
                    //todo: доделать.
                }
                else if (_model.TypeViewPlaylist == AllPlaylistsModel.TypeView.RecomsAlbums)
                {
                    var albums = await loader.GetRecomsAlbums(_model.BlockId);
                    foreach (var album in albums)
                    {
                        Albums.Add(album);
                    }

                    loadingService.Change(false);
                }
            }
            catch (Exception e)
            {
                _notify.CreateNotification("Ошибка при загрузке плейлистов", e.Message);
            }
            

            _isLoading = false;
        }

        public async Task LoadMore()
        {
            if(_model.TypeViewPlaylist == AllPlaylistsModel.TypeView.RecomsAlbums) return;
            
            if (_hasLoadMore && !_isLoading) await Load();
        }
    }
}