using System;
using System.Configuration;

namespace EknowIDLib
{
    public class Constant
    {
        public const String REGISTRATION_SUCCESS = "RegistrationSuccess.html";
        public const String Activate_UserAccount = "ActivateUserAccount.html";
        public const String FORGOT_PASSWORD = "ForgotPassword.html";
        public const String RESET_PASSWORD = "ResetPassword.html";
        public const String DRUG_VERIFICATION = "DrugVerification.html";
        public const String STATUS_COMPLETE = "StatusComplete.html";
        public const String PAYMENT_COMPLETE = "PaymentComplete.html";
        public const String FEEDBACK = "feedback.htm";
        public const String REPLY_TO_FEEDBACK = "Feedback_reply.htm";
        public const String RESUME_CHECKER_SUPPORT = "ResumeCheckerSupport.html";

        public const String CONST_USERNAME = "[USERNAME]";
        public const String CONST_USEREMAILID = "[EMAILID]";
        public const String CONST_USERPASSWORD = "[PASSWORD]";
        public const String CONST_REGISTRATION_SUBJECT = "Welcome to eKnowID";
        public const String CONST_FIRSTNAME = "[FIRSTNAME]";
        public const String CONST_LASTNAME = "[LASTNAME]";
        public const String CONST_COMPANYNAME = "[COMPANY]";
        public const String CONST_UserActivation_SUBJECT = "Please confirm your email for account activation";

        public const String CONST_HOST = "[HOST]";

        public const String CONST_FORGOTLINK = "[FORGOTLINK]";
        public const String CONST_RESETPASSWORD_SUBJECT = "Reset your password – eKnowID";
        public const String CONST_PASSWORD_CHANGE_NOTIFICATION_SUBJECT = "eKnowID Account password changed";
        public const String CONST_ORDERID = "[ORDERID]";
        public const String CONST_ORDERCOMPLETE_SUBJECT = "Your Order is Complete ([ORDERID]) – eKnowID";

        public const String CONST_DRUGVERIFICATION_SUBJECT = "Drug  Verification ordered – eKnowID";
        public const String CONST_PAYMENT_SUCCESS = "Payment and Order Confirmation – eKnowID";

        public const String CONST_CREDIT_REPORT_CREDENTIALING_SUBJECT = "eKnowID Credit Report Credentialing Request";

        public const String CONST_TRANSACTIONID = "[TRANSACTIONID]";
        public const String CONST_ORDERNUMBER = "[ORDERNUMBER]";
        public const String CONST_PURCHASEDATE = "[PURCHASEDATE]";
        public const String CONST_PACKAGENAME = "[PACKAGENAME]";
        public const String CONST_PROFESSION = "[PROFESSION]";
        public const String CONST_COSTOFREPORT = "[COSTOFREPORT]";
        public const String CONST_OPTIONALREPORT = "[OPTIONALREPORT]";
        public const String CONST_DISCOUNTOFFERED = "[DISCOUNTOFFERED]";
        public const String CONST_OTHERCHARGES = "[ACCESSFEE]";
        public const String CONST_TRANSACTIONAMOUNT = "[TRANSACTIONAMOUNT]";
        public const String CONST_MODULENAME = "[MODULENAME]";
        public const String CONST_ADDITIONALREPORTCOST = "Additional Report(s) Cost:";
        public const String CONST_ALACARTREPORTCOST = "Alacart Report(s) Cost:";
        public const String CONST_DEFAULT_SSN = "000000000";
        public const String CONST_DEFAULT_ENCRYPT_SSN = "MDAwMDAwMDAw";

        //Resume checker mail constants

        public const String CONST_MOBILENO = "[MOBILENO]";
        public const String CONST_EMAILADDRESS = "[EMAILADDRESS]";
        public const String CONST_CITY = "[CITY]";
        public const String CONST_STATE = "[STATE]";
        public const String CONST_ZIPCODE = "[ZIPCODE]";

        public const String CONST_SELECTPROFCLASS = "selectProf";
        public const String CONST_PACKAGENAMECLASS = "packageName";
        public const String CONST_PACKAGECOSTCLASS = "packageCost";
        public const String CONST_DISPLAYNONECLASS = "display_none";

        public const String ADMINEMAIL = "support@eknowid.com";
        public const String CONST_CMS_ADMIN_USERID = "kcoats@ekentech.com";

        public const String CONST_PROFILE_DETAILS_SUCCESS = "User details updated successfully.";
        public const String CONST_PROFILE_DETAILS_FAILURE = "User details not updated.";

        public const String CONST_LICENSE_INFORMATION_SUCCESS = "License information updated successfully.";
        public const String CONST_LICENSE_INFORMATION_FAILURE = "License information not updated.";
        public const String CONST_LICENSE_INFORMATION_ADD_SUCCESS = "License information saved successfully.";

        public const String CONST_EDUCATION_INFORMATION_SUCCESS = "Education details updated successfully.";
        public const String CONST_EDUCATION_INFORMATION_FAILURE = "Education details not updated.";
        public const String CONST_EDUCATION_INFORMATION_DELETE_SUCCESS = "Post graduation details removed successfully.";
        public const String CONST_EDUCATION_INFORMATION_ADD_SUCCESS = "Education details saved successfully.";

        public const String CONST_REFERENCE_INFORMATION_SUCCESS = "Reference details updated successfully.";
        public const String CONST_REFERENCE_INFORMATION_FAILURE = "Reference details not updated.";
        public const String CONST_REFERENCE_INFORMATION_DELETE_SUCCESS = "Reference details removed successfully.";
        public const String CONST_REFERENCE_INFORMATION_ADD_SUCCESS = "Reference details saved successfully.";

        public const String CONST_SKILL_SUCCESS = "Skill set updated successfully.";
        public const String CONST_SKILL_INFORMATION_FAILURE = "Skill set not updated.";
        public const String CONST_SKILL_DELETE_SUCCESS = "Skill removed successfully.";
        public const String CONST_LANGUAGE_DELETE_SUCCESS = "Language removed successfully.";
        public const String CONST_SKILL_ADD_SUCCESS = "Skill set saved successfully.";


        public const String CONST_PROFESSIONAL_EXP_SUCCESS = "Professional experience updated successfully.";
        public const String CONST_PROFESSIONAL_EXP_FAILURE = "Professional experience not updated.";
        public const String CONST_PROFESSIONAL_EXP_DELETE_SUCCESS = "Professional experience removed successfully.";
        public const String CONST_PROFESSIONAL_ADD_SUCCESS = "Professional experience saved successfully.";
        public const String SESSION_EXPIRE = "Session Expired";

        public const int CRIMINAL_REPORT_TYPE = 1;
        public const int VERIFICATION_REPORT_TYPE = 2;
        public const int MISCELLANEOUS_REPORT_TYPE = 3;

        public const String EMPLOYMENT_VERIFICATION = "Employment Verification";
        public const String EDUCATION_VERIFICATION = "Education Verification";
        public const String REFERENCE_VERIFICATION = "Reference Verification";
        public const String DRIVING_RECORD = "Driving Record";
        public const String KNOWID_DRUG_TEST = "KnowID Drug Test";

        public const String FEEDBACK_USER_MAILID = "[Email ID]";
        public const String FEEDBACK_SUBJECT = "[SUBJECT]";
        public const String FEEDBACK_COMMENT = "[COMMENTS]";
        public const String FEEDBACK_MAIL_SUBJECT = "Feedback Received";
        public const String FEEDBACK_REPLY_MAIL_SUBJECT = "Thank you for your Feedback";

        public const String SUPPORT_EKNOWID_MAILID = "support@eknowid.com";

        //Module Names
        public const String UNCOVER_BACKGROUND = "Uncover Your Background";
        public const String SECURE_JOB = "Secure Job";
        public const String IDENTITY_THEFT = "Identity Theft";
        public const String RESUME_CHECKER = "Resume Checker";


        public const int ID_THEFT_PROFID = 33;
        public const int UNCOVER_BACKGROUND_PROFID = 34;
        public const int UNCOVER_YOUR_BACKGROUND_PLANID = 19;

        public const int VALIDAGE = 21;


        //Report Name
        public const String IDENTIFY = "IDentify";
        public const String KNOWID_NATIONAL_CRIMINAL_ALIAS = "KnowID National Criminal Alias";
        public const String CREDIT = "Credit";
        public const String CIVIL_SEARCH = "County Civil Courthouse Search";
        public const String COUNTY_CRIMINAL_SEARCH = "County Criminal Courthouse Search";
        public const String FEDERAL_CRIMINAL_SEARCH = "Federal Criminal Courthouse Search";
        public const String STATE_CRIMINAL_SEARCH = "State Criminal Records";


        public const int EDUCATION_REPORT_ID = 2;
        public const int EMPLOYEE_REPORT_ID = 21;
        public const int REFERENCE_REPORT_ID = 3;
        public const int LICENSE_REPORT_ID = 4;
        public const int DRUG_REPORT_ID = 5;
        public const int RESUMECHECKER_REPORT_ID = 23;
        public const int ONSITECOUNTYCHECK_REPORT_ID = 20;

        public const int EDUCATION_REPORT_MAX_VERIFICATION_COUNT = 2;
        public const int EMPLOYEE_REPORT_MAX_VERIFICATION_COUNT = 9;
        public const int REFERENCE_REPORT_MAX_VERIFICATION_COUNT = 5;
        public const int ONSITECOUNTYCHECK_REPORT_MAX_VERIFICATION_COUNT = 5;

        public const String PAYMENT_COMPLETE_SUPPORT = "PaymentCompleteSupport.html";
        public const String CONST_PAYMENT_SUCCESS_SUPPORT = "User Order Details – eKnowID";
        public const String CONST_FREE_RESUME_ANALYSIS_SUPPORT = "Free Resume Analysis was ordered";
        public const String CREDIT_REPORT_CREDENTIALING_SUPPORT = "CreditReportCredentialingRequest.html";

        //Package Name
        public const String BasicPlanType = "Express Lite";
        public const String StandardPlanType = "The Standard";
        public const String PremiumPlanType = "Top Hire";

        //Current Directory        
        public static String CURRENT_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;

        //Email template path
        public static string EmailTemplatePath
        {
            get
            {
                return ConfigurationManager.AppSettings["emailTemplatePath"];
            }
        }

        public static string FromEmailAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["FromEmailAddress"];
            }
        }

        public static string EmailSubject
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailSubject"];
            }
        }

        public static string EmailDisplayName
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailDisplayName"];
            }
        }

        public static string Host
        {
            get
            {
                return ConfigurationManager.AppSettings["Host"];
            }
        }


        ////////////////////////////

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

        public static string DeveloperEmail {
            get {
                return ConfigurationManager.AppSettings["DeveloperEmail"];
            }
        }

        public static string DeveloperEmailDisplayName {
            get {
                return ConfigurationManager.AppSettings["DeveloperEmailDisplayName"];
            }
        }

        public static string DeveloperEmailSubject {
            get {
                return ConfigurationManager.AppSettings["DeveloperEmailSubject"];
            }
        }
    }

    public enum UserTypeEnum
    {
        SUPER_ADMIN = 1,
        ADMIN = 2,
        NORMAL_USER = 3
    }
}
