using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom
{
    public class StatusEnquiry
    {
        public string UserId
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string OrderId
        {
            get;
            set;
        }

        public StatusEnquiryAction Action
        {
            get;
            set;
        }
    }
}
