using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eKnowID.AppCode;
using eKnowID.Pages;
using EknowIDData.Helper;
using System.Collections;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using EknowIDLib;

namespace eKnowID.Controls
{
    public partial class AlacartOrderSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.CouponCode = null;
            if (!IsPostBack)
            {
                //Get selected plan price
                showPlanSummary();
                //if (SessionWrapper.CouponCode != null)
                //{
                //    txtCouponCode.Text = SessionWrapper.CouponCode.ToString();
                //}
            }
            //if (SessionWrapper.CouponCode != null)
            //{
            //    calculateDiscount();
            //}
        }

        protected void lnkBtnApplyCoupon_Click(object sender, EventArgs e)
        {
            calculateDiscount();
        }
        public void showPlanSummary()
        {
            if (SessionWrapper.AlacartReportList.Count != 0)
            {
                List<int> alacartRptIDList = SessionWrapper.AlacartReportList;

                List<Report> alacartReportList = new List<Report>();
                Report report;
                decimal reportTotalPrice = 0;
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
            }
        }
        protected void calculateDiscount()
        {

            //Apply entered coupon

            Decimal total;

            if (string.IsNullOrEmpty(txtCouponCode.Text.Trim().ToString()))
            {
                SessionWrapper.CouponCode = null;
                txtCouponCode.Text = null;
            }

            if ((string.IsNullOrEmpty(txtCouponCode.Text.Trim().ToString())) && (SessionWrapper.CouponCode == null))
            {
                showCouponCodeError();
            }
            else
            {
                string couponCode = "";
                if (!string.IsNullOrEmpty(txtCouponCode.Text.Trim().ToString()))
                {
                    couponCode = txtCouponCode.Text.Trim();
                    SessionWrapper.CouponCode = txtCouponCode.Text.Trim();
                }
                else
                {
                    if (SessionWrapper.CouponCode != null)
                    {
                        couponCode = SessionWrapper.CouponCode.ToString();
                        txtCouponCode.Text = SessionWrapper.CouponCode.ToString();
                    }
                }
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
                        }
                        else if (couponDiscountType != null && couponDiscountType.Name == "Percentage Discount")
                        {
                            total = ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100))) < 0 ? 0 : ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100)));
                            lblTotalPrice.Text = total.ToString("C");
                            hdnPriceDisc.Value = ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) - total).ToString();
                            lblDisCountPrice.Text = (((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100)) < 0 ? 0 : ((decimal.Parse(hdnTotalPriceWithoutDisc.Value)) * ((coupon.DiscountValue) / 100))).ToString("C");
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