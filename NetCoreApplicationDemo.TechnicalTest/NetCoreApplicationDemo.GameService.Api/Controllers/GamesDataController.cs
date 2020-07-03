using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs.Request;
using NetCoreApplicationDemo.TechnicalTest.Games.Interface.ExternalServices;

namespace NetCoreApplicationDemo.GameService.ApiService.Controllers
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
        public async Task<IActionResult> EvaluateGames([FromBody] GamesRequest request)
        {
            try
            {
                _logger.LogInformation(nameof(GamesDataController) + nameof(EvaluateGames));
                var response = await _gamesEvaluator.Evaluate(request);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(string.Format("Exception in {0} --- Error Message: {1}" + nameof(GamesDataController) + nameof(EvaluateGames), ex.Message));
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}