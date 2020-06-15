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
                var p = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var r = await _client.PostAsync("/api/GamesData/Evaluate", p);
                if (r.IsSuccessStatusCode)
                {
                    var jsonString = await r.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GamesResponse>(jsonString);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}