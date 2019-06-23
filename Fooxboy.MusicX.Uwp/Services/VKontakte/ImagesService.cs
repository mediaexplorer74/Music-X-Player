﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Fooxboy.MusicX.Core.Interfaces;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace Fooxboy.MusicX.Uwp.Services.VKontakte
{
    public static class ImagesService
    {

        public async static Task<string> CoverAudio(IAudioFile audio)
        {
            var uriImage = audio.Cover;
            StorageFile coverFile = null;
            var a = await StaticContent.CoversFolder.TryGetItemAsync($"VK{audio.Id}Audio.jpg");
            if (a != null)
            {
                try
                {
                    coverFile = await StaticContent.CoversFolder.GetFileAsync($"VK{audio.Id}Audio.jpg");
                }
                catch
                {
                    coverFile = await StaticContent.CoversFolder.CreateFileAsync($"VK{audio.Id}Audio.jpg");
                    BackgroundDownloader downloader = new BackgroundDownloader();
                    DownloadOperation download = downloader.CreateDownload(new Uri(uriImage), coverFile);
                    await download.StartAsync();
                }

            }
            else
            {
                coverFile = await StaticContent.CoversFolder.CreateFileAsync($"VK{audio.Id}Audio.jpg");
                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(new Uri(uriImage), coverFile);
                await download.StartAsync();
            }

            return coverFile.Path;
        }

        public async static Task<string> CoverPlaylist(IPlaylistFile playlist)
        {
            var uriImage = playlist.Cover;
            StorageFile coverFile;
            try
            {
                coverFile = await StaticContent.CoversFolder.GetFileAsync($"VK{playlist.Id}Playlist.jpg");
            }
            catch
            {
                coverFile = await StaticContent.CoversFolder.CreateFileAsync($"VK{playlist.Id}Playlist.jpg");
                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(new Uri(uriImage), coverFile);
                await download.StartAsync();
            }

            return coverFile.Path;
        }

    }
}