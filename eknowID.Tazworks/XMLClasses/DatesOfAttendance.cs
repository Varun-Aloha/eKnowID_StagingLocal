using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DatesOfAttendance
    {

        [System.Xml.Serialization.XmlElementAttribute("StartDate", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public StartDate StartDate
        {
            get;
            set;
        }
    }
}
