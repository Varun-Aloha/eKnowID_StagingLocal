using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;
using EknowIDModel;
using EknowIDData.Helper;

namespace TazWorksCom.WrapperClasses
{
   public class DrugVerificationWrapper
    {
       private DrugVerificationDetail _drugDetails;
       public DrugVerificationWrapper(DrugVerificationDetail DrugDetails)
       {
           _drugDetails = DrugDetails;
       }

       public DrugScreening GetXMLNode()
       {
           string permissiblePurpose = DrugVerifcationHelper.GetDrugVerificationById(_drugDetails.DrugVerificationId);
           DrugScreening drug = new DrugScreening();
           drug.PermissiblePurpose = permissiblePurpose;
           drug.SpecimenId = _drugDetails.SpecimenId.ToString();
           return drug;
       }
    }
}
