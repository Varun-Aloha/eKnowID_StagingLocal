using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TazWorksCom.XMLClasses.PersonClasses;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]  
    public class educations
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string total { get; set; }

        //[System.Xml.Serialization.XmlElementAttribute("education")]
        //public education education
        //{
        //    get;
        //    set;
        //}

        [XmlElement("education")]
        public List<education> education
        {
            get;
            set;
        }


        
    }
}
