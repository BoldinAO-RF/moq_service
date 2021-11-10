using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoqConfigurator.Models;
using System.Linq;
using MoqConfigurator.Validations;

namespace MoqConfigurator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UseMOQController : ControllerBase
    {
        private readonly ILogger<MOQConfiguratorController> _logger;

        public UseMOQController(ILogger<MOQConfiguratorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Метод получения всего списка элементов
        /// </summary>
        /// <param name="moqName">Вызываемый метод</param>
        /// <returns>Объект</returns>
        [HttpGet]
        [Route("/[controller]/[action]/{moqName}")]
        public IActionResult GetAllMethod(string moqName)
        {
            if (!SingleToneMOQ.MOQs.ValidateByName(moqName))
            {
                return NotFound("Метод не существует в системе");
            }
            if (!SingleToneMOQ.MOQs.ValidateByMethod(moqName, HttpMethods.GET))
            {
                return StatusCode(405);
            }

            var moq = SingleToneMOQ.MOQs.FirstOrDefault(moq => moq.Name.Equals(moqName));

            return StatusCode(moq.ResponseStatusCode, moq.HttpResponse);
        }

        /// <summary>
        /// Метод получения элемента из списка
        /// </summary>
        /// <param name="moqName">Наименование вызываемого метода</param>
        /// <param name="id">Идентификатор элемента из списка</param>
        /// <returns>Объект</returns>
        [HttpGet]
        [Route("/[controller]/[action]/{moqName}/{id}")]
        public IActionResult GetMethod(string moqName, int id)
        {
            if (!SingleToneMOQ.MOQs.ValidateByName(moqName))
            {
                return NotFound("Метод не существует в системе");
            }
            if (!SingleToneMOQ.MOQs.ValidateByMethod(moqName, HttpMethods.GET))
            {
                return StatusCode(405);
            }

            var moq = SingleToneMOQ.MOQs.FirstOrDefault(moq => moq.Name.Equals(moqName));

            return StatusCode(moq.ResponseStatusCode, moq.HttpResponse);
        }

        /// <summary>
        /// Метод создания объекта
        /// </summary>
        /// <param name="moqName">Наименование вызываемого метода</param>
        [HttpPost]
        [Route("/[controller]/[action]/{moqName}")]
        public ActionResult PostMethod(string moqName, string data)
        {
            if (!SingleToneMOQ.MOQs.ValidateByName(moqName))
            {
                return NotFound("Метод не существует в системе");
            }
            if (!SingleToneMOQ.MOQs.ValidateByMethod(moqName, HttpMethods.POST))
            {
                return StatusCode(405);
            }

            var moq = SingleToneMOQ.MOQs.FirstOrDefault(moq => moq.Name.Equals(moqName));

            return StatusCode(moq.ResponseStatusCode);
        }

        /// <summary>
        /// Метод изменения объекта
        /// </summary>
        /// <param name="moqName">Наименование вызываемого метода</param>
        /// <param name="id">Идентификатор изменяемого объекта</param>
        /// <returns>Объект</returns>
        [HttpPut]
        [Route("/[controller]/[action]/{moqName}/{id}")]
        public ActionResult PutMethod(string moqName, int id)
        {
            if (!SingleToneMOQ.MOQs.ValidateByName(moqName))
            {
                return NotFound("Метод не существует в системе");
            }
            if (!SingleToneMOQ.MOQs.ValidateByMethod(moqName, HttpMethods.PUT))
            {
                return StatusCode(405);
            }

            var moq = SingleToneMOQ.MOQs.FirstOrDefault(moq => moq.Name.Equals(moqName));

            return StatusCode(moq.ResponseStatusCode, moq.HttpResponse);
        }

        /// <summary>
        /// Метод удаления объекта
        /// </summary>
        /// <param name="moqName">Наименование вызываемого метода</param>
        /// <param name="id">Идентификатор удаляемого объекта</param>
        [HttpDelete]
        [Route("/[controller]/[action]/{moqName}/{id}")]
        public ActionResult DeleteMethod(string moqName, int id)
        {
            if (!SingleToneMOQ.MOQs.ValidateByName(moqName))
            {
                return NotFound("Метод не существует в системе");
            }
            if (!SingleToneMOQ.MOQs.ValidateByMethod(moqName, HttpMethods.DELETE))
            {
                return StatusCode(405);
            }

            var moq = SingleToneMOQ.MOQs.FirstOrDefault(moq => moq.Name.Equals(moqName));

            return StatusCode(moq.ResponseStatusCode, moq.HttpResponse);
        }
    }
}
