using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SocialGames.TechnicalTest.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class GamesControllers : ControllerBase
    {
        [Route("games/{gameId}/play")]
        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<IActionResult> Play(string gameId)
        {
            return Ok(gameId);
        }
    }
}