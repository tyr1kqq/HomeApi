using HomeApi.Configuration;
using HomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class InfoController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private IOptions<ScreenApiOptions> _options;
        public InfoController(ILogger<WeatherForecastController> logger , IOptions<ScreenApiOptions> options)
        {
            _logger = logger;
            _options = options; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _options.Value.ServerName);
        }
    }
}
