using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class SearchLicense
    {
        [System.Xml.Serialization.XmlElementAttribute("License", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SearchLicenseLicense License
        {
            get;
            set;
        }
    }
}
