using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;

namespace TazWorksCom
{
    public class CreditScreening : ScreeningType
    {
        public CreditScreening()
        {
            //set default values
            type = "credit";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get;
            set;
        }

        //[System.Xml.Serialization.XmlElementAttribute("Vendor", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public CreditVendor Vendor
        //{
        //    get;
        //    set;
        //}
    }
}
