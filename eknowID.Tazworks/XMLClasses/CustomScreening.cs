using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class CustomScreening
    {
        public CustomScreening()
        {
            //set Default values
            type = "custom";
            qualifier = "repository";
            number = "1";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string number { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]      
        public string qualifier { get; set; }
    }
}
