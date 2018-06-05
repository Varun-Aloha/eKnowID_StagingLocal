using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom
{
    public class StringValue : System.Attribute
    {
        private string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }

    public enum StatusEnquiryAction
    {
        [StringValue("status")]
        STATUS = 1,

        [StringValue("credentialedstatus")]
        CREDENTIALED_STATUS = 2
    }
}