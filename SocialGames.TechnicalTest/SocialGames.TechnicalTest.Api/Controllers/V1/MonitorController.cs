using Microsoft.AspNetCore.Mvc;

namespace SocialGames.TechnicalTest.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class MonitorController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Heartbeat()
        {
            return Ok("Hello World");
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}