using NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Request;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApplicationDemo.TechnicalTest.Games.Interface.MainService
{
    public interface IGamesServiceProxyClient
    {
        Task<GamesResponse> EvaluateGamesAsync(GamesRequest request);
    }
}