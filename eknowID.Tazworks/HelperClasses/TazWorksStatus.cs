using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TazWorksCom.HelperClasses
{
    public enum TazWorksStatus
    {
        [StringValue("x:new")]
        NEW=1,
        [StringValue("x:pending")]
        PENDING=2,
        [StringValue("x:failed")]
        FAILED=3,
        [StringValue("x:completed")]
        COMPLETED=4,
        [StringValue("x:message")]
        MESSAGE=5,
        [StringValue("x:canceled")]
        CANCELED=6,
        [StringValue("x:applicant_pending")]
        APPLICANT_PENDING=7,
        [StringValue("x:applicant_process")]
        APPLICANT_PROCESS=8,
        [StringValue("x:error")]
        ERROR=9,
        [StringValue("x:ready")]
        READY = 10
    }
}