using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SocialGames.TechnicalTest.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class GamesControllers : ControllerBase
    {
        [Route("games/{gameId}/play")]
        [HttpPost]
        public async Task<IActionResult> Play(string gameId)
        {
            return Ok(gameId);
        }
    }
}