using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DemographicDetail
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DateOfBirth
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("GovernmentId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public GovernmentId GovernmentId
        {
            get;
            set;
        }
    }
}
