using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    //[System.SerializableAttribute()]    
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = false )]
    //[System.Xml.Serialization.XmlType("Screening")]
    public class ReferenceScreening : ScreeningType
    {
        public ReferenceScreening()
        {
            //Set default Values
            type = "reference";
            //Type = "ReferenceScreening";            
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string qualifier
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("Contact", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ReferenceContact Contact
        {
            get;
            set;
        }
    }
}
