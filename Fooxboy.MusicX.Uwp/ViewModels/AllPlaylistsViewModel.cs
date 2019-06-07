﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fooxboy.MusicX.Uwp.Models;

namespace Fooxboy.MusicX.Uwp.ViewModels
{
    public class AllPlaylistsViewModel : BaseViewModel
    {

        static AllPlaylistsViewModel instanse;
        public static AllPlaylistsViewModel Instanse
        {
            get
            {
                if(instanse == null) instanse = new AllPlaylistsViewModel();

                return instanse;
            }
        }

        private AllPlaylistsViewModel()
        {

        }

        public ObservableCollection<PlaylistFile> Playlists
        {
            get => StaticContent.Playlists;
            set
            {

            }
        }


        private PlaylistFile selectPlaylist;
        public PlaylistFile SelectPlaylist
        {
            get
            {
                return selectPlaylist;
            }
            set
            {
                if(value != null && value != selectPlaylist)
                {
                    selectPlaylist = value;
                    Changed("SelectPlaylist");
                }
            }
        }
    }
}
