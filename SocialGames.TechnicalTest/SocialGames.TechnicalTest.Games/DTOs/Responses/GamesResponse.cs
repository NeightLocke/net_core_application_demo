using System;
using System.Collections.Generic;
using System.Text;

namespace SocialGames.TechnicalTest.Games.DTOs.Responses
{
    public class GamesResponse
    {
        public IEnumerable<CharIndex> GamesDataCollection { get; set; }
    }
}