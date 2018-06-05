using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;
using System.Xml.Serialization;

namespace TazWorksCom
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot("Screenings")]
    public class Screenings
    {     
        //private ScreeningType[] screeningType;
        [XmlElement("Screening")]
        public List<ScreeningType> Screening
        {
            get;
            set;
        }

        [XmlElement("AdditionalItems")]
        public List<AdditionalItems> AdditionalItems
        {
            get;
            set;
        }


        //[System.Xml.Serialization.XmlElementAttribute("Screening", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public ReferenceScreening ReferenceScreening
        //{
        //    get;
        //    set;
        //}
    }
}
