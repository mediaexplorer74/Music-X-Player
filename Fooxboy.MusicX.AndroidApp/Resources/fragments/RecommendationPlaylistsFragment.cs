﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Fooxboy.MusicX.AndroidApp.Adapters;
using Fooxboy.MusicX.AndroidApp.Models;

namespace Fooxboy.MusicX.AndroidApp.Resources.fragments
{
    class RecommendationPlaylistsFragment : Fragment
    {

        public List<PlaylistFile> playlists;
        PlaylistAdapter adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.activity_playlists, container, false);
            adapter = new PlaylistAdapter(playlists);
            adapter.ItemClick += AdapterOnItemClick;
            var list = view.FindViewById<RecyclerView>(Resource.Id.list_playlists);
            list.SetAdapter(adapter);
            list.SetLayoutManager(new GridLayoutManager(Application.Context, 2));
            return view;

        }

        private void AdapterOnItemClick(object sender, PlaylistInBlock args)
        {
            var fragment = new PlaylistFragment();
            fragment.playlist = args.Playlist;
            FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
        }
    }
}