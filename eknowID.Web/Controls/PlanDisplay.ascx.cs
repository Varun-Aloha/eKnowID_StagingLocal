using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using EknowIDModel;
using System.Text.RegularExpressions;
using eknowID.AppCode;
using EknowIDData.Helper;

namespace eknowID.Controls
{
    public partial class PlanDisplay : System.Web.UI.UserControl
    {
        public Plan _plan;
        private List<int> basicReportIds = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Plan plan
        {
            set
            {
                _plan = value;
                lblPlanName.Text = value.Name;
                String[] strVal = String.Format("{0:0.00}", value.Rate).Split(new char[] { '.' }, StringSplitOptions.None);
                lblBasicPrice.Text = strVal[0];
                lblBasicSpecialPricePercent.Text = value.RateOff.ToString() + " %";
                //basicDescriptDiv.InnerHtml = value.Description;
                BindAvailableReports(value.PlanId);
            }
            private get
            {
                return _plan;
            }
        }

        private void BindAvailableReports(int planId)
        {
            List<Report> reports = PlanHelper.GetPlanReports(planId);
            rptBasicReportList.DataSource = reports;
            rptBasicReportList.DataBind();
            if (SessionWrapper.OrderDetail != null && SessionWrapper.OrderDetail.ProfessionId != 0)
            {
                List<Report> optReport = PlanHelper.GetOptionalReports(planId, SessionWrapper.OrderDetail.ProfessionId);
                if (optReport.Count != 0)
                {
                    lblOptRpt.Visible = true;
                    rptOptionalPlans.DataSource = PlanHelper.GetOptionalReports(planId, SessionWrapper.OrderDetail.ProfessionId);
                    rptOptionalPlans.DataBind();
                }
                else
                {
                    lblOptRpt.Visible = false;
                }
            }

            hdnEmpInfoReq.Value = reports.IsEmpInfoRequired().ToString();
            hdnEduInfoReq.Value = reports.IsEduInfoRequired().ToString();
            hdnLicInfoReq.Value = reports.IsLicInfoRequired().ToString();
            hdnRefInfoReq.Value = reports.IsRefInfoRequired().ToString();
            hdnDrugVerificationPlan.Value = reports.IsDrugVerificationRequired().ToString();
            hdnPlanID.Value = planId.ToString();

        }

        protected void imgBtnBasicContinue_Click(object sender, ImageClickEventArgs e)
        {
            //SessionWrapper.OrderDetail.DrugVerificationDetail = null;
            //SessionWrapper.OrderDetail.EducationalDetail = null;
            //SessionWrapper.OrderDetail.EmploymentDetailes = null;
            //SessionWrapper.OrderDetail.LicenseInfo = null;
            //SessionWrapper.OrderDetail.ReferenceInfoes = null;
            //SessionWrapper.CouponCode = null;
            //Session["PaymentFlag"] = false;

            List<int> lstOptionalReportID = new List<int>();
            foreach (RepeaterItem ritem in rptOptionalPlans.Items)
            {
                CheckBox btn = ritem.FindControl("chkBasicOptionalReport") as CheckBox;
                if (btn.Checked == true)
                {
                    Label lbl = ritem.FindControl("lblOptReportID") as Label;
                    lstOptionalReportID.Add(int.Parse(lbl.Text));
                }
            }

            //SessionWrapper.SelectedOptionalReports = lstOptionalReportID;
            SessionWrapper.OrderDetail.PlanId = int.Parse(hdnPlanID.Value);
            SessionWrapper.OrderDetail.OptionalReportIds = lstOptionalReportID;

            //What information is required from user for this plan,stroe values in session
            SessionWrapper.RequiredInformation = null;
            SessionWrapper.RequiredInformation = new RequiredInformation();
            SessionWrapper.RequiredInformation.isEducationDetailsRequired = Convert.ToBoolean(hdnEduInfoReq.Value.ToString());
            SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = Convert.ToBoolean(hdnEmpInfoReq.Value.ToString());
            SessionWrapper.RequiredInformation.isLicenseInformationRequired = Convert.ToBoolean(hdnLicInfoReq.Value.ToString());
            SessionWrapper.RequiredInformation.isReferenceInformationRequired = Convert.ToBoolean(hdnRefInfoReq.Value.ToString());
            SessionWrapper.RequiredInformation.isDrugVerificationRequired = Convert.ToBoolean(hdnDrugVerificationPlan.Value.ToString());

            BaseAbstractClass page = (BaseAbstractClass)Page;
            page.GetDetails();

            string planReport = hdnEmpInfoReq.Value.ToString() + "," + hdnEduInfoReq.Value.ToString() + "," + hdnLicInfoReq.Value.ToString() + "," + hdnRefInfoReq.Value.ToString() + "," + hdnDrugVerificationPlan.Value.ToString();
            Regex reg = new Regex("false", RegexOptions.IgnoreCase);
            int flagCount = reg.Matches(planReport).Count;
            //@@ Commented to show basic information on the Order details// Call Javascript function every time user hit continue button
            //if (flagCount != 5)
            //{
                ScriptManager.RegisterStartupScript(this.Parent.Page, this.Parent.Page.GetType(), "AnUniqueKey", "CheckIfUserloggedIn();", true);
            //}
            //else
            //{
            //    Response.Redirect("SearchByProf_PaymentInfo.aspx?SelectedTab=Payment");
            //}
        }
    }
}