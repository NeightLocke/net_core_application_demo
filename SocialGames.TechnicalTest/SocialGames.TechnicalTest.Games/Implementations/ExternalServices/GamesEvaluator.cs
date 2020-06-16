using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Games.DTOs;
using SocialGames.TechnicalTest.Games.DTOs.Request;
using SocialGames.TechnicalTest.Games.DTOs.Responses;
using SocialGames.TechnicalTest.Games.Interface.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialGames.TechnicalTest.Games.Implementations.ExternalServices
{
    public class GamesEvaluator : IGamesEvaluator
    {
        private const char BreakingCharacter = 'o';
        private readonly ILogger<GamesEvaluator> _logger;

        public GamesEvaluator(ILogger<GamesEvaluator> logger)
        {
            _logger = logger;
        }

        public async Task<GamesResponse> EvaluateGames(GamesRequest request)
        {
            var response = new GamesResponse();
            response.GamesDataCollection = new List<GameSingleDataResponse>();
            request.Games.ToList().ForEach(game =>
            {
                response.GamesDataCollection.Add(GetGameSingleDataResponse(game));
            });
            await Task.Delay(500);
            return response;
        }

        private GameSingleDataResponse GetGameSingleDataResponse(string game)
        {
            var result = new GameSingleDataResponse();
            result.Name = game;
            result.IndexGameDataCollection = new List<CharIndex>();
            for (int i = 0; i < game.Length; i++)
            {
                if (game[i].Equals(BreakingCharacter))
                {
                    break;
                }
                var charIndex = new CharIndex() { Char = game[i], Index = i };
                result.IndexGameDataCollection.Add(charIndex);
            }
            return result;
        }
    }
}