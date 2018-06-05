using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDData.Implementations;
using EknowIDModel;

namespace EknowIDData.Helper
{
   public class ProfessionHelper
    {
       public static string GetProfessionNameById(int ProfessionID)
       {
           Repository<Profession> repository = new Repository<Profession>("ProfessionId");
           return repository.SelectByKey(ProfessionID.ToString()).Name; 
       }
    }
}
