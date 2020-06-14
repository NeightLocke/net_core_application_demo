using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SocialGames.TechnicalTest.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class GamesControllers : ControllerBase
    {
        private readonly ILogger<GamesControllers> _logger;

        public GamesControllers(ILogger<GamesControllers> logger)
        {
            _logger = logger;
        }

        [Route("games/{gameId}/play")]
        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<IActionResult> Play(string gameId)
        {
            _logger.LogInformation(nameof(Play));
            try
            {
                return Ok(gameId);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}