using AngleSharp.Css;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoqConfigurator.Models
{
    public class MOQsModel
    {
        /// <summary>
        /// Наименование MOQ
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Используемый метод передачи данных
        /// </summary>
        [Required]
        public HttpMethods HttpMethods { get; set; }
        /// <summary>
        /// Тело ответа
        /// </summary>
        public string HttpResponse { get; set; }
        /// <summary>
        /// Возвращаемый статус код
        /// </summary>
        [Range(100,600)]
        [Required]
        public int ResponseStatusCode { get; set; }
    }
}
