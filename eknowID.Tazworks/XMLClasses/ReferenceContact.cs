using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ReferenceContact
    {
        

       

        [System.Xml.Serialization.XmlElementAttribute("PersonName")]
        public ReferencePersonName PersonName
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("ContactMethod")]
        public ContactMethod ContactMethod
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Relationship
        {
            get;
            set;
        }
    }
}
