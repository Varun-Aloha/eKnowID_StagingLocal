using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDData.Helper.ResumeParser
{
   public class Education 
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string University { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Degree { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Year { get; set; }
    }
}
