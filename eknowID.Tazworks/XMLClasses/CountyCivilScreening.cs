using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class CountyCivilScreening : ScreeningType
    {
        public CountyCivilScreening()
        {
            //set default values
            type = "civil";
            qualifier = "county";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string qualifier { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Region {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string County {
            get;
            set;
        }
    }
}
