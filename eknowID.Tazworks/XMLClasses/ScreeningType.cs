using eknowID.Tazworks.XMLClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

    [XmlInclude(typeof(LicenseScreening))]
    [XmlInclude(typeof(ReferenceScreening))]
    [XmlInclude(typeof(EmploymentScreening))]
    [XmlInclude(typeof(EducationScreening))]
    [XmlInclude(typeof(CountyCriminalScreening))]
    [XmlInclude(typeof(InstaCriminalMultiStateScreening))]
    [XmlInclude(typeof(InstaCriminalSingleStateScreening))]
    [XmlInclude(typeof(StateCriminalScreening))]    
    [XmlInclude(typeof(SSNScreening))]
    [XmlInclude(typeof(DrugScreening))]
    [XmlInclude(typeof(FederalCriminalScreening))]
    [XmlInclude(typeof(InternationalCriminalScreening))]
    [XmlInclude(typeof(CreditScreening))]
    [XmlInclude(typeof(InstaCriminalNationalAlias))]
    [XmlInclude(typeof(PersonSearchScreening))]
    [XmlInclude(typeof(SexOfferScreening))]
    [XmlInclude(typeof(CountyCivilScreening))]

    public class  ScreeningType
    {
        //private string type = "None";
        //[XmlAttribute]
        //public string Type
        //{
        //    get { return type; }
        //    set { type = value; }
        //}

    }
}
