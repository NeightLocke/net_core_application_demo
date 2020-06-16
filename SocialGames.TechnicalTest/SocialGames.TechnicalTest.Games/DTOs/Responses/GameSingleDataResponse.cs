using System;
using System.Collections.Generic;
using System.Text;

namespace SocialGames.TechnicalTest.Games.DTOs.Responses
{
    public class GameSingleDataResponse
    {
        public string Name { get; set; }

        public IList<CharIndex> IndexGameDataCollection { get; set; }
    }
}