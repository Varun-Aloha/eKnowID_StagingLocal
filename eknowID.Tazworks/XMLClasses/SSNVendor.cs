using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class SSNVendor
    {
        public SSNVendor()
        {
            //Set Default Values
            type = "idsearchplus";
            //hawkalert = "yes";
            high_risk_fraud_alert = "yes";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get;
            set;
        }

        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string hawkalert
        //{
        //    get;
        //    set;
        //}

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string high_risk_fraud_alert
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get;
            set;
        }
    }
}
