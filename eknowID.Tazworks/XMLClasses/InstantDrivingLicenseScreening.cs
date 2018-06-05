using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
   [System.SerializableAttribute()]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public class InstantDrivingLicenseScreening
    {
       public InstantDrivingLicenseScreening()
       {
           //Set Default Values
           type = "license";
           qualifier = "imvPersonal";
       }
       [System.Xml.Serialization.XmlAttributeAttribute()]
       public string type { get; set; }

       [System.Xml.Serialization.XmlAttributeAttribute()]
       public string qualifier { get; set; }

       [System.Xml.Serialization.XmlAttributeAttribute()]
       public string Region { get; set;}

       [System.Xml.Serialization.XmlElementAttribute("SearchLicense", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
       public SearchLicense SearchLicense
       {
           get;
           set;
       }
    }
}
