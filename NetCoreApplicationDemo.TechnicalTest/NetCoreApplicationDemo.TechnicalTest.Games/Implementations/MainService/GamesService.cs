using Microsoft.Extensions.Logging;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Request;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Responses;
using NetCoreApplicationDemo.TechnicalTest.Games.Interface.MainService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApplicationDemo.TechnicalTest.Games.Implementations.MainService
{
    public class GamesService : IGamesService
    {
        private readonly ILogger<GamesServiceProxyClient> _logger;
        private readonly IGamesServiceProxyClient _gamesServiceProxyClient;

        public GamesService(ILogger<GamesServiceProxyClient> logger, IGamesServiceProxyClient gamesServiceProxyClient)
        {
            _logger = logger;
            _gamesServiceProxyClient = gamesServiceProxyClient;
        }

        public async Task<GamesResponse> EvaluateGamesAsync(GamesRequest request)
        {
            _logger.LogInformation(nameof(GamesService) + nameof(EvaluateGamesAsync));
            return await _gamesServiceProxyClient.EvaluateGamesAsync(request);
        }
    }
}