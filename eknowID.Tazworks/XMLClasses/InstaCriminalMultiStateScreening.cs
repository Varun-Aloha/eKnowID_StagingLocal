using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    public class InstaCriminalMultiStateScreening:ScreeningType
    {
        public InstaCriminalMultiStateScreening()
        {
            //set default values
            type = "criminal";
            qualifier = "multistate";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string qualifier { get; set; }
    }
}
