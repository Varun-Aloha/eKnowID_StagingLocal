using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.HelperClasses
{
    public enum CriminalCheckNumber
    {
        [StringValue("default")]
        None = 0,
        [StringValue("County Criminal Check")]
        COUNTY = 1,
        [StringValue("Federal Criminal Check")]
        FEDERAL = 2,
        [StringValue("Instant State Criminal Check (7 Years)")]
        INSTANT_STATE = 3,
        [StringValue("International Criminal Check (7 Years)")]
        INTERNATIONAL_7 = 4,
        [StringValue("International Criminal Check (10 Years)")]
        INTERNATIONAL_10 = 5,
        [StringValue("InstaCriminal Singlestate Search")]
        INSTACRIMINAL_SINGLESTATE = 6,
        [StringValue("InstaCriminal Multistate Search")]
        INSTACRIMINAL_MULTISTATE = 7
    }
}
