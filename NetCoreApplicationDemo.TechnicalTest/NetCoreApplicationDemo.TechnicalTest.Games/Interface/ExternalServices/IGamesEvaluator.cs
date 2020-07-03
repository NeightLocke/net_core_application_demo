using NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Request;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApplicationDemo.TechnicalTest.Games.Interface.ExternalServices
{
    public interface IGamesEvaluator
    {
        Task<GamesResponse> Evaluate(GamesRequest request);
    }
}