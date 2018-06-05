using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses.PersonClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class phonenumbers
    {
        [System.Xml.Serialization.XmlElementAttribute("phonenumber")]
        public phonenumber phonenumber
        {
            get;
            set;
        }
    }
}
