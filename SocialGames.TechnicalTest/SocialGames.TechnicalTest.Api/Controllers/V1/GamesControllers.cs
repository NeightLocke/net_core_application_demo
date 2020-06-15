using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Games.DTOs.Request;
using SocialGames.TechnicalTest.Games.Interface.MainService;
using SocialGames.TechnicalTest.Games.Interface.Shared;

namespace SocialGames.TechnicalTest.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class GamesControllers : ControllerBase
    {
        private readonly ILogger<GamesControllers> _logger;
        private readonly IValidatorProvider _validatorProvider;
        private readonly IGamesService _gamesService;

        public GamesControllers(ILogger<GamesControllers> logger, IValidatorProvider validatorProvider, IGamesService gamesService)
        {
            _logger = logger;
            _validatorProvider = validatorProvider;
            _gamesService = gamesService;
        }

        [Route("games/{gameId}/play")]
        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<IActionResult> Play(string gameId, [FromBody]GamesRequest request)
        {
            _logger.LogInformation(nameof(Play));
            try
            {
                if (_validatorProvider.HasValidId(gameId))
                {
                    var p = await _gamesService.EvaluateGamesAsync(request);
                    return Ok(p);
                }
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}