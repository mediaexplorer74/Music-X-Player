﻿using System;
using System.Collections.Generic;
using System.Text;
using Fooxboy.MusicX.Core.Interfaces;

namespace Fooxboy.MusicX.Core.Models
{
    public class RecommendationsAnyPlatform:IRecommendations
    {
        public List<IBlock> Blocks { get; set; }
    }
}