using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDData.Implementations;
using EknowIDModel;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper
{
   public class DrugVerifcationHelper
    {
       public static DrugVerificationDetail GetDrugVerification(int OrderId)
       {
           Repository<DrugVerificationDetail> repository = new Repository<DrugVerificationDetail>("OrderId");
           DrugVerificationDetail drugDetails = repository.SelectByKey(OrderId.ToString());
           return drugDetails;
       }

       public static string GetDrugVerificationById(int DrugVerificationId)
       {
           Repository<DrugVerification> repository = new Repository<DrugVerification>("DrugVerificationId");
           DrugVerification drug = repository.SelectByKey(DrugVerificationId.ToString());
           return drug.Name;
       }
    }
}
