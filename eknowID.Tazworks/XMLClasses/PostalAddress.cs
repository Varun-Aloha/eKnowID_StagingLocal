using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class PostalAddress
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PostalCode
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Region
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Municipality
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("DeliveryAddress", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DeliveryAddress DeliveryAddress
        {
            get;
            set;
        }
    }
}
