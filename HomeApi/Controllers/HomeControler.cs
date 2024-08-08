using HomeApi.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class HomeControler : ControllerBase
    {
        // Ссылка на объект конфигурации 
        private IOptions<HomeOptions> _options;

        // инициализация конфигурации при вызове конструктора 
        public HomeControler(IOptions<HomeOptions> options)
        {
            _options = options;
        }

        // Метод для получения информации о доме 
        [HttpGet] // Для обслуживания get запросов 
        [Route("info")] // настройка марштрутов с помощью атрибутов 
        public IActionResult Info()
        {
            // Объект stringBilder в котором собираются результат из конфигурации 
            var pageResult = new StringBuilder();

            // Проставляем все значения из конфигурации для последующего вывода на страницу
            pageResult.Append($"Добро пожаловать в API вашего дома {Environment.NewLine}");
            pageResult.Append($"Здесь вы можете посмотреть основную информацию {Environment.NewLine}");
            pageResult.Append(Environment.NewLine);
            pageResult.Append($"Количевсво этажей: {_options.Value.FloorAmount} {Environment.NewLine}");
            pageResult.Append($"Стационарный телефон: {_options.Value.Telephone} {Environment.NewLine}");
            pageResult.Append($"Тип отопления: {_options.Value.Heating} {Environment.NewLine}");
            pageResult.Append($"Напряжение Электросети: {_options.Value.CurrentVolts} {Environment.NewLine}");
            pageResult.Append($"Подключен к газовой сети {_options.Value.GasConnected} {Environment.NewLine}");
            pageResult.Append($"Жилая плозадь: {_options.Value.Area} M2 {Environment.NewLine}");
            pageResult.Append($"Материал: {_options.Value.Material} {Environment.NewLine}");
            pageResult.Append(Environment.NewLine);
            pageResult.Append($"Адресс: {_options.Value.Address.Street}/{_options.Value.Address.House}/{_options.Value.Address.Building}");

            return StatusCode(200 , pageResult.ToString());
        }
    }
    
}
