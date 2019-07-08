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

namespace Fooxboy.MusicX.AndroidApp.Adapters
{
    public class TrackAdapter:BaseAdapter<AudioFile>
    {
        public List<AudioFile> list;

        private Context context;

        public TrackAdapter(Context context, List<AudioFile> list)
        {
            this.list = list;
            this.context = context;
        }

        public override int Count => list.Count;
        public override AudioFile this[int position] => list[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if(view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.TrackLayout, null, false);

                var artist = view.FindViewById<TextView>(Resource.Id.textViewArtist);
                var title = view.FindViewById<TextView>(Resource.Id.textViewTitle);

                artist.Text = list[position].Artist;
                title.Text = list[position].Title;

            }

            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}