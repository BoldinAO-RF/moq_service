using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoqConfigurator.Models;
using System.Collections.Generic;
using System.Linq;
using MoqConfigurator.Validations;

namespace MoqConfigurator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MOQConfiguratorController : ControllerBase
    {
        private readonly ILogger<MOQConfiguratorController> _logger;

        public MOQConfiguratorController(ILogger<MOQConfiguratorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Получить список MOQ
        /// </summary>
        /// <returns>MOQs</returns>
        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult MOQ(HttpMethods? httpMethod)
        {
            if(SingleToneMOQ.MOQs.Count() == 0)
            {
                return NoContent();
            }

            var moqList = httpMethod == null ? SingleToneMOQ.MOQs : SingleToneMOQ.MOQs.Where(item => item.HttpMethods == httpMethod).ToList();

            if(moqList.Count == 0)
            {
                return NoContent();
            }

            return Ok(moqList);
        }

        /// <summary>
        /// Получить MOQ
        /// </summary>
        /// <param name="id">Id MOQ</param>
        /// <returns>MOQ</returns>
        [HttpGet]
        [Route("/[controller]/[action]/{moqName}")]
        public MOQsModel MOQ(string moqName)
        {
            var moq = SingleToneMOQ.MOQs.FirstOrDefault(moq => moq.Name.Equals(moqName));
            return moq;
        }

        /// <summary>
        /// Обновить MOQs
        /// </summary>
        /// <param name="moqs">MOQ</param>
        [HttpPost]
        [Route("/[controller]/[action]")]
        public ActionResult MOQ(List<MOQsModel> moqs)
        {
            if(moqs.Exists(newMoq => SingleToneMOQ.MOQs.ValidateByName(newMoq.Name))
                && SingleToneMOQ.MOQs.Exists(moqs.ForEach(item => item))
            {
                return BadRequest("Метод уже существует");
            }

            SingleToneMOQ.MOQs.AddRange(moqs);
            
            return Ok();
        }

        /// <summary>
        /// Изменить данные MOQ
        /// </summary>
        /// <param name="name">Наименование MOQ</param>
        /// <param name="newMoq">Новое наименование MOQ</param>
        /// <returns></returns>
        [HttpPut]
        [Route("/[controller]/[action]/{name}")]
        public ActionResult MOQ(string name, MOQsModel newMoq)
        {
            SingleToneMOQ.MOQs.ForEach(moq =>
            {
                if (newMoq.Name.Equals(name))
                {
                    moq = newMoq;
                }
            });

            return Ok();
        }
    }
}
