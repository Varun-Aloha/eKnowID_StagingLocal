using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    public class InstaCriminalNationalAlias : ScreeningType
    {
        public InstaCriminalNationalAlias()
        {
            type = "criminal";
            qualifier = "national_alias";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string qualifier
        {
            get;
            set;
        }
    }
}
