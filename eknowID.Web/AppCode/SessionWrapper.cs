using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EknowIDModel;
using EknowIDData.Helper.ResumeParser;

namespace eknowID.AppCode
{
    public static class SessionWrapper
    {
        private static T GetFromSession<T>(string key)
        {
            object obj = HttpContext.Current.Session[key];
            if (obj == null)
            {
                return default(T);
            }
            return (T)obj;
        }

        private static void SetInSession<T>(string key, T value)
        {
            if (value == null)
            {
                HttpContext.Current.Session.Remove(key);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        private static T GetFromApplication<T>(string key)
        {
            return (T)HttpContext.Current.Application[key];
        }

        private static void SetInApplication<T>(string key, T value)
        {
            if (value == null)
            {
                HttpContext.Current.Application.Remove(key);
            }
            else
            {
                HttpContext.Current.Application[key] = value;
            }
        }

        public static string TotalReportPrice
        {
            get { return GetFromSession<string>("TotalReportPrice"); }
            set { SetInSession<string>("TotalReportPrice", value); }
        }
        
        public static User LoggedUser
        {
            get { return GetFromSession<User>("LoggedUser"); }
            set { SetInSession<User>("LoggedUser", value); }
        }

        public static OrderDetails OrderDetail
        {
            get { return GetFromSession<OrderDetails>("OrderDetail"); }
            set { SetInSession<OrderDetails>("OrderDetail", value); }
        }

        public static RequiredInformation RequiredInformation
        {
            get { return GetFromSession<RequiredInformation>("RequiredInformation"); }
            set { SetInSession<RequiredInformation>("RequiredInformation", value); }
        }

        public static int orderStatusID
        {
            get { return GetFromSession<int>("orderStatusID"); }
            set { SetInSession<int>("orderStatusID", value); }
        }

        public static int SelectedPlanType
        {
            get { return GetFromSession<int>("SelectedPackageType"); }
            set { SetInSession<int>("SelectedPackageType", value); }
        }

        public static eknowID.Repositories.User RequesterSignupInformation
        {
            get { return GetFromSession<eknowID.Repositories.User>("RequesterSignupInformation"); }
            set { SetInSession<eknowID.Repositories.User>("RequesterSignupInformation", value); }
        }

        public static int PaymentOrderId
        {
            get { return GetFromSession<int>("PaymentOrderId"); }
            set { SetInSession<int>("PaymentOrderId", value); }
        }        

        public static LinkedinData LinkedinData
        {
            get { return GetFromSession<LinkedinData>("LinkedinData"); }
            set { SetInSession<LinkedinData>("LinkedinData", value); }
        }
        public static string CouponCode
        {
            get { return GetFromSession<string>("CouponCode"); }
            set { SetInSession<string>("CouponCode", value); }
        }

        public static ResumeParserData ResumeParserData
        {
            get { return GetFromSession<ResumeParserData>("ResumeParserData"); }
            set { SetInSession<ResumeParserData>("ResumeParserData", value); }
        }

        public static string ModuleName
        {
            get { return GetFromSession<string>("ModuleName"); }
            set { SetInSession<string>("ModuleName", value); }
        }
        public static List<int> AlacartReportList
        {
            get { return GetFromSession<List<int>>("AlacartReportList"); }
            set { SetInSession<List<int>>("AlacartReportList", value); }
        }

        public static Dictionary<int, int> AlacartReportListWithQty {
            get { return GetFromSession<Dictionary<int, int>>("AlacartReportListWithQty"); }
            set { SetInSession<Dictionary<int, int>>("AlacartReportListWithQty", value); }
        }

        public static string SelectedStates {
            get { return GetFromSession<string>("SelectedStates"); }
            set { SetInSession<string>("SelectedStates", value); }
        }

        public static string SelectedCounties {
            get { return GetFromSession<string>("SelectedCounties"); }
            set { SetInSession<string>("SelectedCounties", value); }
        }

        public static string SelectedCivilCounties {
            get { return GetFromSession<string>("SelectedCivilCounties"); }
            set { SetInSession<string>("SelectedCivilCounties", value); }
        }

        public static string SelectedDistricts {
            get { return GetFromSession<string>("SelectedDistricts"); }
            set { SetInSession<string>("SelectedDistricts", value); }
        }

        public static bool IsCreditReportAuditingChargesPaid {
            get { return GetFromSession<bool>("IsCreditReportAuditingChargesPaid"); }
            set { SetInSession<bool>("IsCreditReportAuditingChargesPaid", value); }
        }

        /// <summary>
        /// SpellErrorData for spell checking on Linkedin and resume upload
        /// </summary>
        public static ResumeRuleCheck ResumeRuleCheck
        {
            get { return GetFromSession<ResumeRuleCheck>("SpellErrorCheck"); }
            set { SetInSession<ResumeRuleCheck>("SpellErrorCheck", value); }
        }

        /// <summary>
        /// Set Payment details
        /// </summary>
        public static PaymentDetails PaymentDetails
        {
            get { return GetFromSession<PaymentDetails>("PaymentDetails"); }
            set { SetInSession<PaymentDetails>("PaymentDetails", value); }
        }

        /// <summary>
        /// Set Content management for Home page Status
        /// </summary>
        public static CMSHomePage CMSHomePage
        {
            get { return GetFromSession<CMSHomePage>("CMSHomePage"); }
            set { SetInSession<CMSHomePage>("CMSHomePage", value); }
        }

        public static int OrderType
        {
            get { return GetFromSession<int>("OrderType"); }
            set { SetInSession<int>("OrderType", value); }
        }

        public static decimal AlacartAccessFees {
            get { return GetFromSession<decimal>("AlacartAccessFees"); }
            set { SetInSession<decimal>("AlacartAccessFees", value); }
        }

        public static decimal HoldingFees {
            get { return GetFromSession<decimal>("HoldingFees"); }
            set { SetInSession<decimal>("HoldingFees", value); }
        }

    }
}