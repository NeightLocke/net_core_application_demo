using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Games.Interface;

namespace SocialGames.TechnicalTest.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class GamesControllers : ControllerBase
    {
        private readonly ILogger<GamesControllers> _logger;
        private readonly IValidatorProvider _validatorProvider;

        public GamesControllers(ILogger<GamesControllers> logger, IValidatorProvider validatorProvider)
        {
            _logger = logger;
            _validatorProvider = validatorProvider;
        }

        [Route("games/{gameId}/play")]
        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<IActionResult> Play(string gameId)
        {
            _logger.LogInformation(nameof(Play));
            try
            {
                if (_validatorProvider.HasValidId(gameId))
                {
                    return Ok(gameId);
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