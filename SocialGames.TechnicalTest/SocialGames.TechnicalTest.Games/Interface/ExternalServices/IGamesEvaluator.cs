using SocialGames.TechnicalTest.Games.DTOs.Request;
using SocialGames.TechnicalTest.Games.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.TechnicalTest.Games.Interface.ExternalServices
{
    public interface IGamesEvaluator
    {
        GamesResponse EvaluateGames(GamesRequest request);
    }
}