using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MoqConfigurator.Models
{
    public static class SingleToneMOQ
    {
        public static List<MOQsModel> MOQs { get; set; } = new List<MOQsModel>();
    }
}
