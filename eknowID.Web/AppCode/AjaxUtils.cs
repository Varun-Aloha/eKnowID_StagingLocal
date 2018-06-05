using EknowIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eknowID.AppCode
{
    public class AjaxUtils
    {


    }

    public class LoginResult
    {
        public Boolean Success
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string TagData
        {
            get;
            set;
        }        
    }

    public class SessionExpired
    {
        public Boolean IsValid
        {
            get;
            set;
        }

    }

    public class ForgotPasswordInfo
    {
        public Boolean Success
        {
            get;
            set;
        }

        public int ForgotPasswordId
        {
            get;
            set;
        }
        public string ErrorMsg
        {
            get;
            set;
        }
    }

    public class ValidationFormat
    {
        public string RegularExpression
        {
            get;
            set;
        }
        public bool IsSSN
        {
            get;
            set;
        }
        //public bool IsLastCharacter
        //{
        //    get;
        //    set;
        //}
        public string SSN
        {
            get;
            set;
        }
        public bool IsUserLoggedIn
        {
            get;
            set;
        }
        public string ErrorMessage
        {
            get;
            set;
        }
    }

    public class Court
    {
        public string OfficeName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    /// <summary>
    /// Store linkedin and resume uploaded data for spell check
    /// </summary>
    public class ResumeRuleCheck
    {
        public string SpellCheckInput { get; set; }
        public bool EmployeeDateGap { get; set; }
        public bool isResumeModule { get; set; }
    }
}