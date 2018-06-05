using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Degree
    {
        public Degree()
        {
            degreeType = "bachelors";
        }

          [System.Xml.Serialization.XmlAttributeAttribute()]
        public string degreeType { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DegreeName { get; set; }
    }
}
