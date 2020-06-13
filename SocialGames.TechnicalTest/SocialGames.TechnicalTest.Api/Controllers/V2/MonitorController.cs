using Microsoft.AspNetCore.Mvc;

namespace SocialGames.TechnicalTest.Api.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    public class MonitorController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("2")]
        [Route("Heartbeat")]
        public IActionResult Heartbeat()
        {
            return Ok(string.Format(nameof(MonitorController) + "_v2"));
        }

        [HttpGet]
        [MapToApiVersion("2")]
        [Route("Ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}