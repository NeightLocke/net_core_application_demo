using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Games.DTOs.Request;
using SocialGames.TechnicalTest.Games.Interface.ExternalServices;

namespace SocialGames.GameService.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesDataController : ControllerBase
    {
        private readonly ILogger<GamesDataController> _logger;
        private readonly IGamesEvaluator _gamesEvaluator;

        public GamesDataController(ILogger<GamesDataController> logger, IGamesEvaluator gamesEvaluator)
        {
            _logger = logger;
            _gamesEvaluator = gamesEvaluator;
        }

        [HttpGet]
        [Route("Version")]
        public IActionResult Version()
        {
            _logger.LogInformation(nameof(Version));
            return Ok(nameof(GamesDataController));
        }

        [HttpPost]
        [Route("Evaluate")]
        public IActionResult EvaluateGames([FromBody] GamesRequest request)
        {
            _logger.LogInformation(nameof(EvaluateGames));
            var response = _gamesEvaluator.EvaluateGames(request);
            return StatusCode((int)HttpStatusCode.OK, response);
        }
    }
}