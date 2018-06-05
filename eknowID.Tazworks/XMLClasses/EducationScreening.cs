using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlType("Screening")]      
    public class EducationScreening : ScreeningType
    {

        public EducationScreening()
        {
            type = "education";
            //Type = "EducationScreening";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Region
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("EducationHistory")]
        public EducationHistory EducationHistory
        {
            get;
            set;
        }

        
    }
}
