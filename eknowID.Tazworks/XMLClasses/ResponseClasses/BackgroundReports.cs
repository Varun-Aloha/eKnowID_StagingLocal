using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class BackgroundReports
    {
        [System.Xml.Serialization.XmlElementAttribute("BackgroundReportPackage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BackgroundReportPackage BackgroundReportPackage
        {
            get;
            set;
        }
    }
}
