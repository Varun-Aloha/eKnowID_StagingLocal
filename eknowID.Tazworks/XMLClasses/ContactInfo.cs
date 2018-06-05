using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ContactInfo
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Telephone
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("PersonName", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ReferencePersonName PersonName
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("PostalAddress", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PostalAddress PostalAddress
        {
            get;
            set;
        }
    }
}
