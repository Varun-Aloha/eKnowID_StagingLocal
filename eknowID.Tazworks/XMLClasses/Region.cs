﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.XMLClasses
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public  class Region
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string region
        {
            get;
            set;
        }
    }
}
