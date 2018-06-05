using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class PersonSearchScreening : ScreeningType
    {
        public PersonSearchScreening()
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

        [System.Xml.Serialization.XmlElementAttribute("Vendor", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PersonSearchVendor Vendor
        {
            get;
            set;
        }
    }
}
