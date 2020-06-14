using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SocialGames.TechnicalTest.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class MonitorController : ControllerBase
    {
        private readonly ILogger<MonitorController> _logger;

        public MonitorController(ILogger<MonitorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [Route("Heartbeat")]
        public IActionResult Heartbeat()
        {
            return Ok(string.Format(nameof(MonitorController) + "_v1"));
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [Route("Ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}