using MoqConfigurator.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoqConfigurator.Validations
{
    public static class ValidationMOQModel
    {
        public static bool ValidateByName(this List<MOQsModel> moqList, string name)
        {
            if (!moqList.Exists(moq => moq.Name.Equals(name)))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateByMethod(this List<MOQsModel> moqList, string name, HttpMethods method)
        {
            if (!moqList.FirstOrDefault(item => item.Name.Equals(name)).HttpMethods.Equals(method.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
