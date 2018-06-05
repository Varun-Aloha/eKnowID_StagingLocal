using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class WorkersCompensationScreening
    {
        public WorkersCompensationScreening()
        {
            type = "workcomp";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("Region", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Region Region
        {
            get;
            set;
        }
    }
}
