using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ResidentScreening
    {
        public ResidentScreening()
        {
            type = "resident";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string StartDate { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("ContactInfo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ContactInfo ContactInfo
        {
            get;
            set;
        }
    }
}
