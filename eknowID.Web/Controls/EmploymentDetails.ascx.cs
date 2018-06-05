using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDData.Interfaces;
using EknowIDModel;
using EknowIDModel.UserProfile;
using EknowIDData.Implementations;
using EknowIDData.Helper;
using eknowID.AppCode;
using System.Text;
using EknowIDLib;

namespace eknowID.Controls
{
    public partial class EmploymentDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionWrapper.LoggedUser != null)
            {
                int qty = 1;
                if (null != SessionWrapper.AlacartReportListWithQty && SessionWrapper.AlacartReportListWithQty.Any(p => p.Key.Equals(Constant.EMPLOYEE_REPORT_ID))) {
                    qty = SessionWrapper.AlacartReportListWithQty[Constant.EMPLOYEE_REPORT_ID];                    
                }
                if (SessionWrapper.ResumeParserData == null && SessionWrapper.LinkedinData == null)
                {
                    qty = SetUserEmploymentInfo(qty);
                }
                else if (SessionWrapper.ResumeParserData != null)
                {
                    qty = SetFromSessionData(qty);
                }
                else if (SessionWrapper.LinkedinData != null)
                {
                    qty = SetFromLinkedIn(qty);
                }

                employmentDetailsCount.Value = qty.ToString();
            }
        }

        private int SetFromLinkedIn(int qty)
        {
            if (SessionWrapper.LinkedinData.EmploymentDetailes.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "AddEmpControl(" + SessionWrapper.LinkedinData.EmploymentDetailes.Count + ");", true);
                FillInformation(SessionWrapper.LinkedinData.EmploymentDetailes);
                return checkEmpDetailsCountWithSelectedQty(SessionWrapper.LinkedinData.EmploymentDetailes.Count, qty);
            }
            return qty;
        }

        private int checkEmpDetailsCountWithSelectedQty(int count, int selectedQty) {
            if(count < selectedQty) {
                return (selectedQty - count) + 1;
            }
            return 1;
        }

        private int SetFromSessionData(int qty)
        {
            List<UserEmploymentDetail> userEmpDetails = new List<UserEmploymentDetail>();
            int proCount = SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory.Count;
            UserEmploymentDetail userEmpDetail;
            for (int i = 0; i < proCount; i++)
            {
                userEmpDetail = new UserEmploymentDetail();
                userEmpDetail.OrgName = SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[i].Employer;
                userEmpDetail.City = SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[i].JobLocation.EmployerCity;
                userEmpDetail.PositionTitle = SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[i].JobLocation.EmployerCity;
                userEmpDetail.Description = SessionWrapper.ResumeParserData.SegregatedExperience.WorkHistory[i].JobDescription;
                userEmpDetails.Add(userEmpDetail);

            }
            if (userEmpDetails.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "AddEmpControl(" + userEmpDetails.Count + ");", true);
                FillInformation(userEmpDetails);
                return checkEmpDetailsCountWithSelectedQty(userEmpDetails.Count, qty);
            }
            return qty;
        }

        private int SetUserEmploymentInfo(int qty)
        {
           List<UserEmploymentDetail> userEmpDetails = UserEmploymentDetailsHelper.GetEmploymentDetailsListByUserId(SessionWrapper.LoggedUser.UserId);
           if (userEmpDetails.Count > 0)
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "AddEmpControl(" + userEmpDetails.Count + ");", true);
               FillInformation(userEmpDetails);
                return checkEmpDetailsCountWithSelectedQty(userEmpDetails.Count, qty);
           }
            return qty;

            //UserProfessionalExprience userProfessionalExprience = UserEmploymentDetailsHelper.GetUserProfessionalExprienceByUserId(SessionWrapper.LoggedUser.UserId);

            //if (userProfessionalExprience != null)
            //{
            //    txtOrgName_1.Text = userProfessionalExprience.OrgName;
            //    txtProfCity_1.Text = userProfessionalExprience.City;
            //    txtTelephoneNumber_1.Text = userProfessionalExprience.Telephone;
            //    ddlStateEmp.Index = userProfessionalExprience.StateId;

            //    List<UserPositionInformed> list = UserEmploymentDetailsHelper.GetPositionInfoList(userProfessionalExprience.UserProfessionalExprienceId);
            //    if (list.Count > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "AddEmpControl(" + list.Count + ");", true);
            //        FillInformation(list);
            //    }
            //}
        }

        private void FillInformation(List<UserEmploymentDetail> List)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=text/javascript>");
            for (int i = 0; i < List.Count; i++)
            {
                //string  numberMonths = "0 Months";
                //if (List[i].EndDate!=null)
                //{
                //    DateTime endDatedu = List[i].EndDate.HasValue ? List[i].EndDate.Value : DateTime.Now;
                //    numberMonths = ((endDatedu.Year - List[i].StartDate.Year) * 12) + endDatedu.Month - List[i].StartDate.Month +" Months";
                //}
                sb.Append("orgName.push('" + List[i].OrgName + "');");
                sb.Append("city.push('" + List[i].City + "');");
                sb.Append("state.push('" + List[i].StateId + "');");
                sb.Append("telephone.push('" + List[i].Telephone + "');");

                sb.Append("PositionTitle.push('" + List[i].PositionTitle + "');");
                
                //sb.Append("StartDt.push('" + List[i].StartDate.ToString("MM/dd/yyyy") + "');");
                //string endDate = List[i].EndDate.HasValue ? List[i].EndDate.Value.ToString("MM/dd/yyyy") : "";
                //sb.Append("EndDt.push('" + endDate + "');");

                sb.Append("startMonth.push('" + List[i].StartMonth + "');");
                sb.Append("startYear.push('" + List[i].StartYear + "');");
                sb.Append("endMonth.push('" + List[i].EndMonth + "');");
                sb.Append("endYear.push('" + List[i].EndYear + "');");

                sb.Append("Descript.push('" + List[i].Description + "');");
                sb.Append("isAttending.push('" + List[i].IsAttending + "');");

                sb.Append("empdetailsId.push('" + List[i].UserEmploymentDetailId + "');");
                //sb.Append("numberMonths.push('" + numberMonths + "');");

            }
            sb.Append("SetEmpDetails();");
            sb.Append("</script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        }
    }
}