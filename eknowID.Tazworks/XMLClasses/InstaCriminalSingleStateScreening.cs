using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{

    public class InstaCriminalSingleStateScreening :ScreeningType
    {
        public InstaCriminalSingleStateScreening()
        {
            //set default values
            type = "criminal";
            qualifier = "singlestate";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string qualifier { get; set; }



        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Region
        {
            get;
            set;
        }
    }
}
