using HomeApi.Configuration;
using HomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {

        private readonly IHostEnvironment _env;
        private readonly ILogger<WeatherForecastController> _logger;
        public DevicesController(ILogger<WeatherForecastController> logger , IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
        }

        // Поиск и загрузка инструкции по использованию устройства 
        [HttpGet]
        [HttpHead]
        [Route("{manufacturer}")]
        public IActionResult GetManual([FromRoute] string manufacturer)
        {
            var staticPath = Path.Combine(_env.ContentRootPath, "Static");
            var filePath = Directory.GetFiles(staticPath)
                .FirstOrDefault(f => f.Split("\\")
                .Last()
                .Split('.')[0] == manufacturer);

            if (String.IsNullOrEmpty(filePath))
                return StatusCode(404, $"Инструкции для производителя {manufacturer} не найдено , проверьте название");

            string fileType = "applicatio/jpg";
            string fileName = $"{manufacturer}.jpg";

            return PhysicalFile(filePath, fileType , fileName);
        }
    }
}
