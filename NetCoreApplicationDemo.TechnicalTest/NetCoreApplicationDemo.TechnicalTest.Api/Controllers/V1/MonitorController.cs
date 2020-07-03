using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace NetCoreApplicationDemo.TechnicalTest.Api.Controllers.V1
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
            _logger.LogInformation(nameof(Heartbeat));
            try
            {
                return Ok(string.Format(nameof(MonitorController) + "_v1"));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [Route("Ping")]
        public IActionResult Ping()
        {
            _logger.LogInformation(nameof(Ping));
            try
            {
                return Ok("Pong");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}