﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fooxboy.MusicX.AndroidApp.Models;
using Java.Interop;
using Object = Java.Lang.Object;

namespace Fooxboy.MusicX.AndroidApp.Adapters
{
    public class TrackAdapter:BaseAdapter<AudioFile>
    {
        public List<AudioFile> list { get; set; }

        private Context context;

        private ListView listView;

        public TrackAdapter(Context context, List<AudioFile> list, ListView listview) :base()
        {
            this.list = list;
            this.context = context;
            this.listView = listview;
        }

        public override int Count => list.Count;
        public override AudioFile this[int position] => list[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            TextView artist;
            TextView title;
            if (convertView == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TrackLayout, parent, false);

                artist = view.FindViewById<TextView>(Resource.Id.textViewArtist);
                title = view.FindViewById<TextView>(Resource.Id.textViewTitle);


                artist.Text = list[position].Artist;
                title.Text = list[position].Title;

                view.SetTag(Resource.Id.textViewArtist, list[position].Artist);
                view.SetTag(Resource.Id.textViewTitle, list[position].Title);

                view.SetOnClickListener(null);
                // listView.Scroll += ListView_Scroll;
            }
            else
            {
                artist = view.FindViewById<TextView>(Resource.Id.textViewArtist);
                title = view.FindViewById<TextView>(Resource.Id.textViewTitle);
            }

            AudioFile a = GetItem(position);
            artist.Text = a.Artist;
            title.Text = a.Title;

            return view;
        }

        private void ListView_Scroll(object sender, AbsListView.ScrollEventArgs e)
        {
            
        }

        public void GetMoreItems()
        {

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public AudioFile GetItem(int position)
        {
            return list[position];
        }

    }
}