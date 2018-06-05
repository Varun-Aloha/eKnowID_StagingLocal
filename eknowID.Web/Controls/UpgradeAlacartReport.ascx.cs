using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using eknowID.Pages;
using EknowIDData.Helper;
using System.Collections;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using EknowIDLib;

namespace eknowID.Controls
{
    public partial class UpgradeAlacartReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.CouponCode = null;
            if (!IsPostBack)
            {
                //Get selected plan price
                SessionWrapper.AlacartReportList = new List<int>();
                showPlanSummary();

            }
        }
       
        public void showPlanSummary()
        {
            decimal reportTotalPrice = 0;

            int selectedPlanId = SessionWrapper.OrderDetail.PlanId;
            Plan plan = PlanHelper.GetPlan(SessionWrapper.OrderDetail.PlanId);
            Decimal PlanPrice = (plan == null) ? 0 : plan.Rate;
            lblPlanPrice.Text = PlanPrice.ToString("C");
            //Get plan reports for display

            List<EknowIDModel.Report> reports = PlanHelper.GetPlanReports(selectedPlanId);
            rptBasicReportList.DataSource = reports;
            rptBasicReportList.DataBind();

            reportTotalPrice = PlanPrice;

            string planName = PlanHelper.GetPlan(selectedPlanId).Name.ToString();

            if (planName == "Basic")
                imgPaymentHeader.ImageUrl = "~/Images/payment_checkout_basic_2.png";
            if (planName == "Gold")
                imgPaymentHeader.ImageUrl = "~/Images/payment_checkout_gold_2.png";
            if (planName == "Platinum")
                imgPaymentHeader.ImageUrl = "~/Images/payment_checkout_platinum_2.png";

            if (SessionWrapper.AlacartReportList.Count != 0)
            {
                List<int> alacartRptIDList = SessionWrapper.AlacartReportList;

                List<Report> alacartReportList = new List<Report>();
                Report report;

                foreach (int reportID in alacartRptIDList)
                {
                    report = new Report();
                    report = PlanHelper.GetReportByReportID(reportID);
                    reportTotalPrice = reportTotalPrice + report.Price.Value;
                    alacartReportList.Add(report);
                }
                rptOptionalReportList.DataSource = alacartReportList;
                rptOptionalReportList.DataBind();
            }
            else {
                List<Report> alacartReportList = new List<Report>();
                rptOptionalReportList.DataSource = alacartReportList;
                rptOptionalReportList.DataBind();
            }
            lblTotalPrice.Text = reportTotalPrice.ToString("C");
            hdnTotalPriceWithoutDisc.Value = reportTotalPrice.ToString();
        }        
       
    }
}