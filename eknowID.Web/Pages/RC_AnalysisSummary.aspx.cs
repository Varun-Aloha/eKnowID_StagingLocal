using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using eknowID.AppCode;
using System.Web.Services;
using EknowIDLib;
using EknowIDModel;
using EknowIDData.Helper;
using EknowIDModel.UserProfile;
using System.Linq;
using System.Web.UI;
using eknowID.Pages;

namespace eknowID.Pages
{
    public partial class RC_AnalysisSummary : System.Web.UI.Page
    {
        public static bool isEmpDateGap;
        public List<ResumeChecker_AlacartReport> alacartReportDispalyList;
        private static string dictionaryPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SessionWrapper.ResumeRuleCheck = new ResumeRuleCheck();
                SessionWrapper.ResumeRuleCheck.isResumeModule = true;
                dictionaryPath = Server.MapPath("../dictionary/dict-large.txt");
            }

            catch { }
        }

        [WebMethod]
        public static FreeResumeCheck getSpellErrorCheckData()
        {
            string spellErrorData = string.Empty;
            FreeResumeCheck freeResumeCheck = new FreeResumeCheck();
            try
            {
                if (SessionWrapper.ResumeParserData != null)
                {
                    freeResumeCheck.SpellErrorData = SetFromUploadResumeData(spellErrorData);
                }
                if (SessionWrapper.LinkedinData != null)
                {
                    freeResumeCheck.SpellErrorData = SetFromLinkedIn(spellErrorData);
                    freeResumeCheck.IsEmployeeDateGap = SessionWrapper.ResumeRuleCheck.EmployeeDateGap == true ? true : false;
                }
                freeResumeCheck = checkSpellError(freeResumeCheck);
            }
            catch { }
            return freeResumeCheck;

        }

        /// <summary>
        /// Send Resume Checker mail to support team.
        /// </summary>
        private static void SendResumeCheckMail()
        {
            try
            {
                StringBuilder emailBodyPaymentSupport = new StringBuilder(ConstructMail.GetMailBody(Constant.RESUME_CHECKER_SUPPORT));
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_FIRSTNAME, SessionWrapper.ResumeParserData.FirstName);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_LASTNAME, SessionWrapper.ResumeParserData.LastName);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_MOBILENO, SessionWrapper.ResumeParserData.Mobile);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_EMAILADDRESS, SessionWrapper.ResumeParserData.Email);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_CITY, SessionWrapper.ResumeParserData.City);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_STATE, SessionWrapper.ResumeParserData.State);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_ZIPCODE, SessionWrapper.ResumeParserData.ZipCode);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_SELECTPROFCLASS, Constant.CONST_DISPLAYNONECLASS);

                SendMail.Sendmail(Constant.ADMINEMAIL, Constant.CONST_FREE_RESUME_ANALYSIS_SUPPORT, emailBodyPaymentSupport.ToString());
            }
            catch { }
        }

        private static string SetFromLinkedIn(string spellErrorData)
        {
            spellErrorData = spellErrorData + " " + SessionWrapper.LinkedinData.EducationalDetail.Basic;
            spellErrorData = spellErrorData + " " + SessionWrapper.LinkedinData.EducationalDetail.Specialization;
            spellErrorData = spellErrorData + " " + SessionWrapper.LinkedinData.EducationalDetail.University;
            spellErrorData = spellErrorData + " " + SessionWrapper.LinkedinData.Postgraduation.PostGraduation;
            spellErrorData = spellErrorData + " " + SessionWrapper.LinkedinData.Postgraduation.Specialization;
            spellErrorData = spellErrorData + " " + SessionWrapper.LinkedinData.Postgraduation.University;

            List<UserEmploymentDetail> userEmpDetails = SessionWrapper.LinkedinData.EmploymentDetailes;
            spellErrorData = GetEmpInfo(userEmpDetails, spellErrorData);

            return spellErrorData;
        }

        //Get Spell Error Check data
        private static string SetFromUploadResumeData(string spellErrorData)
        {
            //Get Contact Info

            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.FirstName;
            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.Middlename;
            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.LastName;
            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.Email;
            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.Address;
            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.Address;
            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.City;
            spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.ZipCode;

            //Get Education Info
            if (SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit.Count > 0)
            {
                spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[0].Degree;
                spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[0].Degree;
                spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[0].Institution.Name;

                if (SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit.Count > 1)
                {
                    spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[1].Degree;
                    spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[1].Degree;
                    spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[1].Institution.Name;
                }
            }

            //Get Employment Info
            int proCount = SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory.Count;

            for (int count = 0; count < proCount; count++)
            {
                spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[count].Employer;
                spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[count].JobLocation;
                spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[count].JobProfile;
                spellErrorData = spellErrorData + " " + SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[count].JobDescription;
            }

            return spellErrorData;
        }

        private static string GetEmpInfo(List<UserEmploymentDetail> EmpList, string spellErrorData)
        {
            EmploymentDetail empDetails;
            List<EmploymentDetail> EmployeeDateGapCheck = new List<EmploymentDetail>();
            try
            {
                for (int loopCounter = 0; loopCounter < EmpList.Count; loopCounter++)
                {

                    spellErrorData = spellErrorData + " " + EmpList[loopCounter].OrgName;
                    spellErrorData = spellErrorData + " " + EmpList[loopCounter].City;
                    spellErrorData = spellErrorData + " " + EmpList[loopCounter].StateId;
                    spellErrorData = spellErrorData + " " + EmpList[loopCounter].Telephone;
                    spellErrorData = spellErrorData + " " + EmpList[loopCounter].PositionTitle;
                    spellErrorData = spellErrorData + " " + EmpList[loopCounter].Description;


                    empDetails = new EmploymentDetail();
                    empDetails.StartMonth = EmpList[loopCounter].StartMonth;
                    empDetails.StartYear = EmpList[loopCounter].StartYear;
                    empDetails.EndMonth = EmpList[loopCounter].EndMonth;
                    empDetails.EndYear = EmpList[loopCounter].EndYear;
                    empDetails.IsAttending = Convert.ToBoolean(EmpList[loopCounter].IsAttending);
                    empDetails.EmploymentDetailId = loopCounter;

                    string month = empDetails.StartMonth != 0 ? empDetails.StartMonth.ToString("00") : "01";
                    string year = empDetails.StartYear != 0 ? empDetails.StartYear.ToString() : "1900";
                    string startDate = "01/" + month + "/" + year;
                    DateTime StartDate = DateTime.ParseExact(startDate, "MM/dd/yyyy", null);
                    empDetails.StartDate = StartDate;

                    month = empDetails.EndMonth != 0 ? empDetails.EndMonth.ToString("00") : "01";
                    year = empDetails.EndYear != 0 ? empDetails.EndYear.ToString() : "1900";
                    string endDate = "01/" + month + "/" + year;
                    DateTime EndDate = DateTime.ParseExact(endDate, "MM/dd/yyyy", null);
                    empDetails.EndDate = EndDate;

                    EmployeeDateGapCheck.Add(empDetails);
                }
                checkEmployeeDateGap(EmployeeDateGapCheck);
            }
            catch
            { }
            return spellErrorData;
        }

        /// <summary>
        /// Check Employee Date gap
        /// </summary>
        /// <param name="List"></param>
        public static void checkEmployeeDateGap(List<EmploymentDetail> EmploymentDetailList)
        {
            try
            {
                List<EmploymentDetail> startDateAscending = new List<EmploymentDetail>();
                startDateAscending = EmploymentDetailList;

                var DateList = from startDateAscOrder in startDateAscending
                               orderby startDateAscOrder.StartDate ascending
                               select startDateAscOrder;
                startDateAscending = DateList.ToList();


                //If no end date no gap
                bool GapFlag = false;
                foreach (EmploymentDetail empDetail in startDateAscending)
                {
                    if (empDetail.EndMonth != 0 && empDetail.EndYear != 0)
                    {
                        GapFlag = true;
                    }
                }
                if (GapFlag == false)
                {
                    SessionWrapper.ResumeRuleCheck.EmployeeDateGap = false;
                    return;
                }


                foreach (EmploymentDetail startDt in startDateAscending)
                {
                    foreach (EmploymentDetail dt in startDateAscending)
                    {
                        if (dt.EmploymentDetailId != startDt.EmploymentDetailId && (startDt.EndMonth != 0 && startDt.EndYear != 0))
                        {
                            if (dt.StartDate > startDt.EndDate && dt.StartMonth - startDt.EndMonth != 1)
                            {
                                SessionWrapper.ResumeRuleCheck.EmployeeDateGap = true;
                                return;
                            }
                        }
                    }
                }
                if (GapFlag == false)
                {
                    SessionWrapper.ResumeRuleCheck.EmployeeDateGap = false;
                    return;
                }
            }
            catch { }
        }

        /// <summary>
        /// Check spell error
        /// </summary>
        /// <param name="freeResumeCheck"></param>
        /// <returns></returns>
        public static FreeResumeCheck checkSpellError(FreeResumeCheck freeResumeCheck)
        {
            char[] delimiters = new[] { ',', ' ', '(', ')', '.',':' };
            string[] SpellErrorDataList = freeResumeCheck.SpellErrorData.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int errorCount = 0;
            int isNumeric;          
            string SpellErrorList = string.Empty;

            try
            {
                for (int loopCounter = 0; loopCounter < SpellErrorDataList.Length; loopCounter++)
                {
                    if ((File.ReadAllText(dictionaryPath).Contains(SpellErrorDataList[loopCounter].ToLower().Trim()) == false) && (System.Text.RegularExpressions.Regex.IsMatch(SpellErrorDataList[loopCounter].Trim(), @"\d") == false) && (SpellErrorDataList[loopCounter] != string.Empty))
                    {
                        if (!SpellErrorList.Contains(SpellErrorDataList[loopCounter]))
                        {
                            SpellErrorList = SpellErrorList + " " + SpellErrorDataList[loopCounter];
                            errorCount++;
                        }
                    }
                }
                if (SessionWrapper.ResumeParserData != null)
                {
                    SendResumeCheckMail();
                }
            }
            catch { }
            freeResumeCheck.SpellErrorList = SpellErrorList;
            freeResumeCheck.SpellErrorCount = errorCount;
          

            return freeResumeCheck;
        }
    }

    public class FreeResumeCheck
    {
        public string SpellErrorData { get; set; }
        public string SpellErrorList { get; set; }
        public int SpellErrorCount { get; set; }
        public bool IsEmployeeDateGap { get; set; }
    }
}