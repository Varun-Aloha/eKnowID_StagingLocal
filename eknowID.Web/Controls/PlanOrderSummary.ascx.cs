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
    public partial class PlanOrderSummary : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        { 
            if(SessionWrapper.ModuleName==Constant.UNCOVER_BACKGROUND)
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setUncoverBackgroundListHeight();", true);
            else
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setReportListHeight();", true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {              
                showPlanSummary();
            }  
            
        }

        protected void lnkBtnApplyCoupon_Click(object sender, EventArgs e)
        {
            calculateDiscount();
        }
        protected void showPlanSummary()
        {

             decimal reportTotalPrice = 0;

            int selectedPlanId = SessionWrapper.OrderDetail.PlanId;
            Plan plan = PlanHelper.GetPlan(SessionWrapper.OrderDetail.PlanId);
            Decimal PlanPrice = (plan == null) ? 0 : plan.Rate;
            lblPlanPrice.Text = PlanPrice.ToString("C");
            //Get plan reports for display
            var accessFees = SessionWrapper.AlacartAccessFees;
            var holdingFees = SessionWrapper.HoldingFees;

            List<EknowIDModel.Report> reports = PlanHelper.GetPlanReports(selectedPlanId);
            rptBasicReportList.DataSource = reports;
            rptBasicReportList.DataBind();

            reportTotalPrice = PlanPrice;
            if (SessionWrapper.ModuleName != Constant.UNCOVER_BACKGROUND)
            {
                string planName = PlanHelper.GetPlan(selectedPlanId).Name.ToString();

                if (planName == "Basic")
                    imgPaymentHeader.ImageUrl = "~/Images/payment_checkout_basic_2.png";
                if (planName == "Gold")
                    imgPaymentHeader.ImageUrl = "~/Images/payment_checkout_gold_2.png";
                if (planName == "Platinum")
                    imgPaymentHeader.ImageUrl = "~/Images/payment_checkout_platinum_2.png";
            }
            else
            {
                imgPaymentHeader.ImageUrl = "~/Images/checkout_blue.png";
            }
            if (SessionWrapper.AlacartReportList.Count != 0)
            {
                List<int> alacartRptIDList = SessionWrapper.AlacartReportList;
                Dictionary<int, int> alacartRptIDListWithQty = SessionWrapper.AlacartReportListWithQty;
                List<Report> alacartReportList = new List<Report>();
                Report report;

                foreach (int reportID in alacartRptIDList)
                {
                    report = new Report();
                    report = PlanHelper.GetReportByReportID(reportID);
                    var qty = report.qty = (null != alacartRptIDListWithQty && alacartRptIDListWithQty.Any(p => p.Key.Equals(reportID))) ? alacartRptIDListWithQty[reportID] : 1;
                    if ("State Criminal Records" == report.Name) {
                    reportTotalPrice = reportTotalPrice + (report.Price.Value * qty);
                    }
                    else {
                        reportTotalPrice = reportTotalPrice + (report.Price.Value * qty);
                    }
                    alacartReportList.Add(report);
                }
                reportTotalPrice += holdingFees + accessFees;
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

            if(0 < accessFees) {
                divAccessFees.Visible = true;
                lblAccessFees.Text = accessFees.ToString("C");
            }
            if (0 < holdingFees) {
                divHoldingFees.Visible = true;
                lblHoldingFees.Text = holdingFees.ToString("C");
            }
           
        }
        protected void calculateDiscount()
        {

            //Apply entered coupon

            Decimal total;

            if (string.IsNullOrEmpty(txtCouponCode.Text.Trim().ToString()))
            {
                showCouponCodeError();
            }
            else
            {
                string couponCode = "";
                couponCode = txtCouponCode.Text.Trim();               
                Coupon coupon = CouponHelper.GetCouponByCode(couponCode);
                if (coupon != null)
                {
                    if (coupon.CouponDiscountTypeId > 0)
                    {
                        CouponDiscountType couponDiscountType = CouponDiscountTypeHelper.GetCouponTypeById(coupon.CouponDiscountTypeId);
                        if (couponDiscountType != null && couponDiscountType.Name == "Price Discount")
                        {
                            total = (decimal.Parse(hdnTotalPriceWithoutDisc.Value) - coupon.DiscountValue) < 0 ? 0 : (decimal.Parse(hdnTotalPriceWithoutDisc.Value) - coupon.DiscountValue);
                            lblTotalPrice.Text = total.ToString("C");
                            hdnPriceDisc.Value = ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - total).ToString();
                            lblDisCountPrice.Text = coupon.DiscountValue.ToString("C");
                            SessionWrapper.PaymentDetails.discountOffered = ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - total);
                            SessionWrapper.PaymentDetails.couponID = coupon.CouponDiscountTypeId;
                        }
                        else if (couponDiscountType != null && couponDiscountType.Name == "Percentage Discount")
                        {
                            total = ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100))) < 0 ? 0 : ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100)));
                            lblTotalPrice.Text = total.ToString("C");
                            hdnPriceDisc.Value = ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - total).ToString();
                            lblDisCountPrice.Text = (((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100)) < 0 ? 0 : ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100))).ToString("C");
                            SessionWrapper.PaymentDetails.discountOffered = ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - total);
                            SessionWrapper.PaymentDetails.couponID = coupon.CouponDiscountTypeId;
                        }
                        lblDisCountPrice.Visible = true;
                        lblDiscountOffer.Visible = true;
                    }
                    hdnCouponID.Value = coupon.CouponId.ToString();
                    lblErrorCouponCode.ForeColor = System.Drawing.Color.LimeGreen;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "couponCodeError('Coupon code is valid.');", true);
                }
                else
                {
                    showPlanSummary();
                    lblDisCountPrice.Visible = false;
                    lblDiscountOffer.Visible = false;
                    lblErrorCouponCode.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "couponCodeError('Coupon code is invalid.');", true);
                }
            }
        }

        protected void showCouponCodeError()
        {
            Decimal total = (decimal.Parse(hdnTotalPriceWithoutDisc.Value));
            lblTotalPrice.Text = total.ToString("C");
            lblDisCountPrice.Visible = false;
            lblDiscountOffer.Visible = false;
            lblErrorCouponCode.ForeColor = System.Drawing.Color.Red;
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