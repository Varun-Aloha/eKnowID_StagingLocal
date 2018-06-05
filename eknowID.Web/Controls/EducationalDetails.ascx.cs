using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using EknowIDModel;
using EknowIDData.Helper;
using eknowID.AppCode;
using EknowIDModel.UserProfile;
using System.Text;
using EknowIDLib;

namespace eknowID.Controls
{
    public partial class EducationalDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (SessionWrapper.LoggedUser != null) {
                if (SessionWrapper.ResumeParserData == null && SessionWrapper.LinkedinData == null) {
                        SetUserEducationalInfo();
                } else if (SessionWrapper.ResumeParserData != null) {
                    SetFromSessionData();
                } else if (SessionWrapper.LinkedinData != null) {
                    SetFromLinkedIn();
                    }
                if (null != SessionWrapper.AlacartReportListWithQty && SessionWrapper.AlacartReportListWithQty.Any(p => p.Key.Equals(Constant.EDUCATION_REPORT_ID))) {
                    var qty = SessionWrapper.AlacartReportListWithQty[Constant.EDUCATION_REPORT_ID];
                    if (1 < qty) {
                        Post.Style.Remove("display");
                        divUserPost.Style.Remove("display");
                        BtnAdd.Style.Add("display", "none");
                        btnRemovePostGraduation.Style.Add("display", "none");
                    }                
                }
            }
           
        }

        private void SetFromLinkedIn()
        {
            if (SessionWrapper.LinkedinData.EducationalDetail != null)
            {
                txtBasic.Text = string.IsNullOrEmpty(SessionWrapper.LinkedinData.EducationalDetail.Basic) == true ? string.Empty : SessionWrapper.LinkedinData.EducationalDetail.Basic;
                txtSpecialization.Text = string.IsNullOrEmpty(SessionWrapper.LinkedinData.EducationalDetail.Specialization) == true ? string.Empty : SessionWrapper.LinkedinData.EducationalDetail.Specialization;
                txtUniversity.Text = string.IsNullOrEmpty(SessionWrapper.LinkedinData.EducationalDetail.University) == true ? string.Empty : SessionWrapper.LinkedinData.EducationalDetail.University;
            }
            divUserPost.Style.Add("display", "block");
            Post.Style.Add("display", "block");
            BtnAdd.Style.Add("display", "none");
            if (SessionWrapper.LinkedinData.Postgraduation != null)
            {
                txtPostGraduation.Text = string.IsNullOrEmpty(SessionWrapper.LinkedinData.Postgraduation.PostGraduation) == true ? string.Empty : SessionWrapper.LinkedinData.Postgraduation.PostGraduation;
                txtPostSpecialization.Text = string.IsNullOrEmpty(SessionWrapper.LinkedinData.Postgraduation.Specialization) ? string.Empty : SessionWrapper.LinkedinData.Postgraduation.Specialization;
                txtPostUniversity.Text = string.IsNullOrEmpty(SessionWrapper.LinkedinData.Postgraduation.University) ? string.Empty : SessionWrapper.LinkedinData.Postgraduation.University;
            }
        }

        private void SetFromSessionData()
        {
            if (SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit.Count > 0)
            {
                txtBasic.Text = SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[0].Degree;
                txtSpecialization.Text = SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[0].Degree;
                txtUniversity.Text = SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[0].Institution.Name;

                if (SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit.Count > 1)
                {
                    divUserPost.Style.Add("display", "block");
                    Post.Style.Add("display", "block");
                    BtnAdd.Style.Add("display", "none");

                    txtPostGraduation.Text = SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[1].Degree;
                    txtPostSpecialization.Text = SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[1].Degree;
                    txtPostUniversity.Text = SessionWrapper.ResumeParserData.SegregatedQualification.EducationSplit[1].Institution.Name;
                }
            }

        }  

        private void SetUserEducationalInfo()
        {            
            UserEducationalDetail userEducationalInfo = UserEducationalDetailHelper.GetUserEducationalDetailByUserId(SessionWrapper.LoggedUser.UserId);

            int postStartYear = 0;
            int postEndYear = 0;
            int startYear = 0;
            int endYear = 0;

            if (userEducationalInfo != null)
            {
                txtBasic.Text = userEducationalInfo.Basic;
                txtSpecialization.Text = userEducationalInfo.Specialization;                
                txtUniversity.Text = userEducationalInfo.University;
                txtMunicipality.Text = userEducationalInfo.Municipality;
                ddlMonthStart.SelectedIndex = userEducationalInfo.StartMonth;              
                ddlMonthEnd.SelectedIndex = userEducationalInfo.EndMonth;                
                ddlStateEducation.Index = userEducationalInfo.StateId.HasValue ? userEducationalInfo.StateId.Value : 0;
                chkAttending.Checked = userEducationalInfo.IsAttending;

                startYear = userEducationalInfo.StartYear;
                endYear = userEducationalInfo.EndYear;

                //if (userEducationalInfo.IsAttending)
                //{
                //    BtnAdd.Style.Add("display", "none");
                //}

               // FillInformation(userEducationalInfo.StartYear, userEducationalInfo.EndYear);
            }

            UserPostGraduation userPostGraduation = UserEducationalDetailHelper.GetUserPostGraduationDetailByUserId(SessionWrapper.LoggedUser.UserId);
            if (userPostGraduation != null)
            {
                divUserPost.Style.Remove("display");
                Post.Style.Remove("display");
                BtnAdd.Style.Add("display", "none");
                hdnPostGraduation.Value = userPostGraduation.UserPostGraduationId.ToString();
                txtPostGraduation.Text = userPostGraduation.PostGraduation;
                txtPostSpecialization.Text = userPostGraduation.Specialization;
                txtPostUniversity.Text = userPostGraduation.University;
                txtPostMuncipality.Text = userPostGraduation.Municipality;
                ddlStatePostEducation.Index = userPostGraduation.StateId;
                ddlPostMonthEnd.SelectedIndex = userPostGraduation.EndMonth;
                ddlPostMonthStart.SelectedIndex = userPostGraduation.StartMonth;
                

                chkPostAttending.Checked = userPostGraduation.IsAttending;

                //if (userPostGraduation.IsAttending)
                //{
                //    chkAttending.Style.Add("display", "none");
                //}

                postEndYear = userPostGraduation.EndYear;
                postStartYear = userPostGraduation.StartYear;

                //FillPostInformation(userPostGraduation.StartYear, userPostGraduation.EndYear);
            }

            FillInformation(startYear, endYear, postStartYear, postEndYear);

        }

        private void FillInformation(int startYearEd, int endYearEdu, int postStartYear, int postEndYear)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=text/javascript>");

            sb.Append("startYearEdu.push('" + startYearEd + "');");
            sb.Append("endYearEdu.push('" + endYearEdu + "');");

            sb.Append("startYearPost.push('" + postStartYear + "');");
            sb.Append("endYearPost.push('" + postEndYear + "');");

            sb.Append("SetEducationsDetails();");
            sb.Append("</script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        }

        //private void FillPostInformation(int startYear, int endYear)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<script type=text/javascript>");

        //    sb.Append("startYearPost.push('" + startYear + "');");
        //    sb.Append("endYearPost.push('" + endYear + "');");

        //    sb.Append("SetPostGraduationDetails();");            
        //    sb.Append("</script>");

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        //}
    }
}