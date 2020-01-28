﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Fooxboy.MusicX.Uwp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Fooxboy.MusicX.Uwp.Services;
using Windows.UI.Popups;
using Fooxboy.MusicX.Core.Interfaces;
using Fooxboy.MusicX.Uwp.Resources.ContentDialogs;
using Windows.Storage;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace Fooxboy.MusicX.Uwp.Resources.Controls
{
    public sealed partial class PlaylistControl : UserControl
    {

        public static readonly DependencyProperty PlaylistProperty = DependencyProperty.Register("Album",
            typeof(Album), typeof(PlaylistControl), new PropertyMetadata(new Album
            {
                Year = 2020,
                Artists = new List<IArtist>(),
                Followers = 0,
                Description = "",
                Cover = "ms-appx:///Assets/Images/placeholder-album.png",
                Genres = new List<string>(),
                Id = -2,
                IsAvailable = false,
                IsFollowing = false,
                OwnerId = -2,
                Plays = 0,
                TimeCreate = DateTime.Now,
                TimeUpdate = DateTime.Now,
                Title = "",
                Tracks = new List<ITrack>(),
                Type = 0
            }));

        public PlaylistControl()
        {
            this.InitializeComponent();
            PlayCommand = new RelayCommand( async () =>
            {
               
            });

            DeleteCommand = new RelayCommand(async () =>
            {
               
            }); 
        }


        public Album Album
        {
            get => (Album)GetValue(PlaylistProperty);
            set
            {
                SetValue(PlaylistProperty, value);
            }
        }

        public RelayCommand PlayCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        private async void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {

            await CoverPlaylist.Scale(centerX: 50.0f,
                        centerY: 50.0f,
                        scaleX: 1.1f,
                        scaleY: 1.1f,
                        duration: 200, delay: 0).StartAsync();
        }

        private async void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            await CoverPlaylist.Scale(centerX: 50.0f,
                        centerY: 50.0f,
                        scaleX: 1.0f,
                        scaleY: 1.0f,
                        duration: 200, delay: 0).StartAsync();

            
        }
    }
}
