using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    public class SSNScreening:ScreeningType
    {
        public SSNScreening()
        {
            //set default values
            type = "personsearch";   
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get;
            set;
        }

        //[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public string Vendor
        //{
        //    get;
        //    set;
        //}

        [System.Xml.Serialization.XmlElementAttribute("Vendor", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SSNVendor Vendor
        {
            get;
            set;
        }
    }
}
