using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class PersonalReferenceScreening
    {
        [System.Xml.Serialization.XmlElementAttribute("Contact", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ReferenceContact Contact
        {
            get;
            set;
        }
    }
}
