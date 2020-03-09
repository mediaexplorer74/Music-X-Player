﻿using DryIoc;
using Fooxboy.MusicX.Uwp.Services;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.MusicX.Uwp.ViewModels
{
    public class LoadingViewModel:BaseViewModel
    {
        public bool IsLoading { get; set; }

        public LoadingViewModel()
        {
            var service = Container.Get.Resolve<LoadingService>();
            service.LoadingChangedEvent += Service_LoadingChangedEvent;
        }

        private void Service_LoadingChangedEvent(bool result)
        {
            IsLoading = result;
            DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Changed("IsLoading");
            });
        }
    }
}
