using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    public class LicenseScreening : ScreeningType
    {
        public LicenseScreening()
        {
            //Set Default Values
            type = "license";
            Region = "CT";
            //Type = "LicenseScreening";
            qualifier = "imvPersonal";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string qualifier
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


        [System.Xml.Serialization.XmlElementAttribute("SearchLicense", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SearchLicense SearchLicense
        {
            get;
            set;
        }
    }
}
