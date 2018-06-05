using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PersonalData
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EmailAddress
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Telephone
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("PersonName")]
        public PersonName PersonName
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("Aliases")]
        public Aliases Aliases
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("DemographicDetail", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DemographicDetail DemographicDetail
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("PostalAddress")]
        public PostalAddress PostalAddress
        {
            get;
            set;
        }
    }
}
