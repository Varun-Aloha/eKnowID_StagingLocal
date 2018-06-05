using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public class EducationHistory
    {
          [System.Xml.Serialization.XmlElementAttribute("SchoolOrInstitution")]
        public SchoolOrInstitution SchoolOrInstitution
        {
            get;
            set;
        }
    }
}
