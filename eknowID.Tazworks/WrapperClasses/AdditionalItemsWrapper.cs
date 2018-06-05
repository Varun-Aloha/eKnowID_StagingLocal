using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;

namespace TazWorksCom.WrapperClasses
{
   public class AdditionalItemsWrapper
    {
       public static AdditionalItems AddCredentials()
       {
           AdditionalItems additionalItems = new AdditionalItems();
           additionalItems.Text = "TRUE";
           return additionalItems;
       }
    }
}
