using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Aliases
    {
        [System.Xml.Serialization.XmlElementAttribute("PersonName")]
        public PersonName PersonName
        {
            get;
            set;
        }
    }
}
