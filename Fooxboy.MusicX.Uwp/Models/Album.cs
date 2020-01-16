﻿using Fooxboy.MusicX.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.MusicX.Uwp.Models
{
    public class Album : IAlbum
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Title { get; set; }
        public List<IArtist> Artists { get; set; }
        public string Cover { get; set; }
        public string AccessKey { get; set; }
        public List<ITrack> Tracks { get; set; }
        public List<string> Genres { get; set; }
        public long Plays { get; set; }
        public long Year { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
        public DateTime TimeUpdate { get; set; }
        public DateTime TimeCreate { get; set; }
        public long Followers { get; set; }
        public bool IsFollowing { get; set; }
        public long Type { get; set; }
    }
}
