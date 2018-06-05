using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;

namespace eknowID.Tazworks.XMLClasses
{
    public class SexOfferScreening : ScreeningType
    {
        public SexOfferScreening()
        {
            type = "sex_offender";
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
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
    }
}
