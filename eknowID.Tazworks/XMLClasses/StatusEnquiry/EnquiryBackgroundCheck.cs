using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TazWorksCom.StatusEnqiury
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class BackgroundCheck
    {
        public BackgroundCheck()
        {
            //fetch userid and password from config and assign them here
            userId=ConfigurationManager.AppSettings["TazWorksUserId"];
            password = ConfigurationManager.AppSettings["TazWorksPwd"];
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string userId
        {
            get;
            set;
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string password
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("BackgroundSearchPackage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EnquiryBackgroundSearchPackage BackgroundSearchPackage
        {
            get;
            set;
        }
    }
}
