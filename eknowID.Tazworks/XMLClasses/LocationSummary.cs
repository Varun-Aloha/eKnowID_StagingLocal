using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LocationSummary
    {   
        //[System.Xml.Serialization.XmlElementAttribute("Municipality", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public Municipality Municipality
        //{
        //    get;
        //    set;
        //}

        //[System.Xml.Serialization.XmlElementAttribute("Region", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public Region Region
        //{
        //    get;
        //    set;
        //}

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Municipality
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
