using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TazWorksCom.XMLClasses.PersonClasses;

namespace TazWorksCom.XMLClasses
{
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlType("Screening")]      
    public class positions
    {       
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string total { get; set; }

        //[System.Xml.Serialization.XmlElementAttribute("position")]
        //public position position
        //{
        //    get;
        //    set;
        //}

        [XmlElement("position")]
        public List<position> position
        {
            get;
            set;
        }


        
    }
}
