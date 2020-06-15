using System;
using System.Collections.Generic;
using System.Text;

namespace SocialGames.TechnicalTest.Games.DTOs.Request
{
    public class GamesRequest
    {
        public IEnumerable<string> Games { get; set; }
    }
}