using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses.PersonClasses;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class position
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string id
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string title
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string summary
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("StartDate")]
        public PositionStartDate StartDate
        {
            get;
            set;
        }
        [System.Xml.Serialization.XmlElementAttribute("EndDate")]
        public PositionEndDate EndDate
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IsCurrent
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("company")]
        public company company
        {
            get;
            set;
        }
    }
}
