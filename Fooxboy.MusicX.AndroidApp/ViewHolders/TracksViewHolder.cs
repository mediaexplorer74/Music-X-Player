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
using Fooxboy.MusicX.AndroidApp.Interfaces;
using ImageViews.Rounded;

namespace Fooxboy.MusicX.AndroidApp.ViewHolders
{
    public class TracksViewHolder : RecyclerView.ViewHolder, View.IOnClickListener,  View.IOnLongClickListener
    {
        public TextView Title { get; private set; }
        public TextView Artist { get; private set; }
        public TextView Duration { get; private set; }
        public RoundedImageView Cover { get; private set; }

        public TracksViewHolder(View itemView) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.textViewTitle);
            Artist = itemView.FindViewById<TextView>(Resource.Id.textViewArtist);
            Duration = itemView.FindViewById<TextView>(Resource.Id.DurationTrack);
            Cover = itemView.FindViewById<RoundedImageView>(Resource.Id.imageViewCover);
            itemView.SetOnClickListener(this);
            itemView.SetOnLongClickListener(this);
        }
        
        
        public void SetItemClickListener(IItemClickListener listener)
        {
            this.itemClickListener = listener;
        }
        private IItemClickListener itemClickListener;
        
        public void OnClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition, false);
        }

        public bool OnLongClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition, true);
            return true;
        }
    }
}