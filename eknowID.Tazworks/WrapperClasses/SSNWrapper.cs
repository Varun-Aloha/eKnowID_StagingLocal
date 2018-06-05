using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;

namespace TazWorksCom.WrapperClasses
{
   public class SSNWrapper
    {
       public static SSNScreening AddSocialSecuritySearch()
       {
           SSNScreening ssn = new SSNScreening();
           //ssn.Vendor = new SSNVendor();
           //ssn.Vendor.high_risk_fraud_alert = "yes";
           //ssn.Vendor.type = "idsearchplus";
           //ssn.Vendor.Value = "transUnion";
           return ssn;
       }
    }
}
