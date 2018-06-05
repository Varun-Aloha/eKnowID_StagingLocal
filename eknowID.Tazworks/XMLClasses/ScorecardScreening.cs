using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ScorecardScreening
    {
        public ScorecardScreening()
        {
            type = "scorecard";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("LinkedApplicants", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LinkedApplicants LinkedApplicants
        {
            get;
            set;
        }

    }
}
