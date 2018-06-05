using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses.PersonClasses;

namespace TazWorksCom.XMLClasses
{

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]   
    public class person
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string headline
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FirstName
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LastName
        {
            get;
            set;
        }
                
        [System.Xml.Serialization.XmlElementAttribute("educations", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public educations educations
        {
            get;
            set;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("positions", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public positions Positions
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("phonenumbers")]
        public phonenumbers phonenumbers
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MainAddress
        {
            get;//phone-numbers 
            set;
        }
    }
}
