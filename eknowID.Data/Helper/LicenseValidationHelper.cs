using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDData.Implementations;
using EknowIDModel;

namespace EknowIDData.Helper
{
   public class LicenseValidationHelper
    {
       public static ValidationRule GetValidationRuleById(int ValidationRuleId)
       {
            Repository<ValidationRule> repository = new Repository<ValidationRule>("ValidationRuleId");
            return repository.SelectByKey(ValidationRuleId.ToString());           
       }
    }
}
