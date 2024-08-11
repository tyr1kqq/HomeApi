using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // Ссылка на объект конфигурации 
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        // инициализация конфигурации при вызове конструктора 
        public HomeController(IOptions<HomeOptions> options , IMapper mapper)
        {
            _mapper = mapper;
            _options = options;
        }

        // Метод для получения информации о доме 
        [HttpGet] // Для обслуживания get запросов 
        [Route("info")] // настройка марштрутов с помощью атрибутов 
        public IActionResult Info()
        {
            // получим запрос "спаспив" конфигурацию на модель запроса 
            var infoResponcse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
            // Вернем ответ 
            return StatusCode(200, infoResponcse); 
        }
    }
    
}
