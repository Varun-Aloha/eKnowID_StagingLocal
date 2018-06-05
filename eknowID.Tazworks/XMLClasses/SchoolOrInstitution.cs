using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class SchoolOrInstitution
    {
        public SchoolOrInstitution()
        {
            schoolType = "university";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schoolType { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SchoolName { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("LocationSummary", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LocationSummary LocationSummary
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("Degree", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Degree Degree
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("DatesOfAttendance", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DatesOfAttendance DatesOfAttendance
        {
            get;
            set;
        }
    }
}
