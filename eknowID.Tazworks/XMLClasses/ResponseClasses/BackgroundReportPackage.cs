using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class BackgroundReportPackage
    {
        public BackgroundReportPackage()
        {
            ReportURL = String.Empty;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ReferenceId
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OrderId
        {
            get;
            set;
        }

        //[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public string InstantInterfaceURL
        //{
        //    get;
        //    set;
        //}
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ReportURL
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("ScreeningStatus", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ScreeningStatus ScreeningStatus
        {
            get;
            set;
        }
    }
}
