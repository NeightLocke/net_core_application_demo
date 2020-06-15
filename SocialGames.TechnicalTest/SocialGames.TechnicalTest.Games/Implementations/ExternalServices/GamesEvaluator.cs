using SocialGames.TechnicalTest.Games.DTOs;
using SocialGames.TechnicalTest.Games.DTOs.Request;
using SocialGames.TechnicalTest.Games.DTOs.Responses;
using SocialGames.TechnicalTest.Games.Interface.ExternalServices;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SocialGames.TechnicalTest.Games.Implementations.ExternalServices
{
    public class GamesEvaluator : IGamesEvaluator
    {
        public GamesResponse EvaluateGames(GamesRequest request)
        {
            var charIndexItem = new CharIndex() { Char = 'A', Index = 0 };
            var charIndexCollection = new List<CharIndex>() { charIndexItem };
            var response = new GamesResponse()
            {
                GamesDataCollection = charIndexCollection
            };
            Thread.Sleep(5000);
            return response;
        }
    }
}