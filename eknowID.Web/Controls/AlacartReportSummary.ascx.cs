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
    public partial class AlacartReportSummary : System.Web.UI.UserControl
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

        protected void lnkBtnApplyCoupon_Click(object sender, EventArgs e)
        {
          
        }
        public void showPlanSummary()
        {
            //if (SessionWrapper.AlacartReportList.Count != 0)
            //{
                List<int> alacartRptIDList = SessionWrapper.AlacartReportList;

                List<Report> alacartReportList = new List<Report>();
                Report report;
                decimal reportTotalPrice=0;
                foreach (int reportID in alacartRptIDList)
                {
                    report = new Report();
                    report = PlanHelper.GetReportByReportID(reportID);
                    reportTotalPrice = reportTotalPrice + report.Price.Value;
                    alacartReportList.Add(report);
                }
                rptBasicReportList.DataSource = alacartReportList;
                rptBasicReportList.DataBind();
              
                lblTotalPrice.Text = reportTotalPrice.ToString("C");
                hdnTotalPriceWithoutDisc.Value = reportTotalPrice.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setReportListWidth();", true);
            //}
        }
      

        protected void showCouponCodeError()
        {
            Decimal total = (decimal.Parse(hdnTotalPriceWithoutDisc.Value));
            lblTotalPrice.Text = total.ToString("C");
            hdnPriceDisc.Value = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "couponCodeError('Please enter coupon code.');", true);
        }
        public int CouponId
        {
            get
            {
                int couponId = 0;
                Int32.TryParse(hdnCouponID.Value, out couponId);
                return couponId;
            }
        }

        public Decimal OfferedAmount
        {
            get
            {
                Decimal OfferedRptAmount = 0;
                Decimal.TryParse(hdnPriceDisc.Value, out OfferedRptAmount);
                return OfferedRptAmount;
            }
        }
    }
}