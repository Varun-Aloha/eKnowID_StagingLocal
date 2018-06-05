using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TazWorksCom
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnquiryBackgroundSearchPackage
    {
        public EnquiryBackgroundSearchPackage()
        {
            //type will be unique we can fetch and assign it here
            //type = ConfigurationManager.AppSettings["TazWorksProduct"];
            action = "status";
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OrderId
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get;
            set;
        }

        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string type
        //{
        //    get;
        //    set;
        //}

        //[System.Xml.Serialization.XmlElementAttribute("PersonalData", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public PersonalData PersonalData
        //{
        //    get;
        //    set;
        //}

        //[System.Xml.Serialization.XmlElementAttribute("Screenings", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public Screenings Screenings
        //{
        //    get;
        //    set;
        //}

    }
}
