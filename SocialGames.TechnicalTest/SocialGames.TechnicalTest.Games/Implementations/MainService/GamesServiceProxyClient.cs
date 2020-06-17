using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialGames.TechnicalTest.Games.DTOs;
using SocialGames.TechnicalTest.Games.DTOs.Request;
using SocialGames.TechnicalTest.Games.DTOs.Responses;
using SocialGames.TechnicalTest.Games.Interface.MainService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.TechnicalTest.Games.Implementations.MainService
{
    public class GamesServiceProxyClient : IGamesServiceProxyClient
    {
        private readonly ILogger<GamesServiceProxyClient> _logger;
        private HttpClient _client = new HttpClient();

        public GamesServiceProxyClient(ILogger<GamesServiceProxyClient> logger, GamesServiceProxyClientConfiguration proxyClientConfig)
        {
            _logger = logger;
            _client.BaseAddress = new Uri(proxyClientConfig.BaseAddressClientConfiguration);
        }

        public async Task<GamesResponse> EvaluateGamesAsync(GamesRequest request)
        {
            try
            {
                _logger.LogInformation(nameof(GamesServiceProxyClient) + nameof(EvaluateGamesAsync));
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var result = await _client.PostAsync("/api/GamesData/Evaluate", content);
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GamesResponse>(jsonString);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception in {0} --- Error Message: {1}" + nameof(GamesServiceProxyClient) + nameof(EvaluateGamesAsync), ex.Message));
                throw ex;
            }
        }
    }
}