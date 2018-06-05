using System.Configuration;

namespace eknowID.Repositories.Constant
{
    public class EknowIdConstant
    {
        public static string ExpressLiteOffer
        {
            get
            {
                return ConfigurationManager.AppSettings["ExpressLiteOffer"];
            }
        }

        public static string StandardOffer
        {
            get
            {
                return ConfigurationManager.AppSettings["StandardOffer"];
            }
        }

        public static string TopHireOffer
        {
            get
            {
                return ConfigurationManager.AppSettings["TopHireOffer"];
            }
        }

        public static string WrapperPartnerApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["WrapperPartnerApiKey"];
            }
        }
    }

    public enum WrapperStatusEnum
    {
        [StringValue("email_opend")] // treat as a applicant email is open
        email_opened = 0,
        [StringValue("accept")] // treat as a email sent
        accept = 1,
        [StringValue("inprogress")] // treat as a assessment order is in progress into eknowid only
        inprogress = 2,
        [StringValue("complete")] // treat as a order completed.
        complete = 4,
        [StringValue("message")] // treat as a order is place for applicant / order initialize.
        order_place = 5,
        [StringValue("reject")] // treat as a order is reject.
        reject = 6,
        [StringValue("x:error")] // treat as a order is Error.
        error = 9,
        [StringValue("results")]  // treat as a order is ready for report.
        results = 10,
    }

    public enum TazWorksStatus
    {
        [StringValue("x:new")]
        NEW = 1,
        [StringValue("x:pending")]
        PENDING = 2,
        [StringValue("x:failed")]
        FAILED = 3,
        [StringValue("x:completed")]
        COMPLETED = 4,
        [StringValue("x:message")]
        MESSAGE = 5,
        [StringValue("x:canceled")]
        CANCELED = 6,
        [StringValue("x:applicant_pending")]
        APPLICANT_PENDING = 7,
        [StringValue("x:applicant_process")]
        APPLICANT_PROCESS = 8,
        [StringValue("x:error")]
        ERROR = 9,
        [StringValue("x:ready")]
        READY = 10,
        [StringValue("x:app_pending")]
        APP_PENDING = 11,
        [StringValue("x:applicant-ready")]
        APPLICANT_READY = 12,
        [StringValue("x:incomplete")]
        INCOMPLETE = 13
    }

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
}
