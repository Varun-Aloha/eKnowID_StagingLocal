using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class CreditVendor
    {
        public CreditVendor()
        {
            //set default credit score and fraud attribute values
            score = "yes";
            fraud = "yes";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fraud
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
