﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Responses
{
    public class GamesResponse
    {
        public IList<GameSingleDataResponse> GamesDataCollection { get; set; }
    }
}