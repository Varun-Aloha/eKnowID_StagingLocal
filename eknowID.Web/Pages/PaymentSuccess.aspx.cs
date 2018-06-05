using System;
using System.Collections.Generic;
using System.Web.UI;
using eknowID.AppCode;
using EknowIDLib;
using EknowIDData.Helper;
using EknowIDModel;
using System.Globalization;
using System.Text;

namespace eknowID.Pages
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionWrapper.LoggedUser == null)
            {
                Response.Redirect("~/Pages/index.aspx");
            }
            //Set & show Payment Details.
            SetSummaryData();
        }
        public void SetSummaryData()
        {
            try
            {
                string userName = string.Empty;
                string TransactionID = string.Empty;
                int orderID = 0;
                string totalReportCost = string.Empty;
                string accessFees = string.Empty;
                string holdingFees = string.Empty;
                Decimal discountOffered = 0;
                int selectedPlanId = SessionWrapper.OrderDetail.PlanId;
                string selectedProf;
                Decimal PlanPrice = 0;

                if (SessionWrapper.PaymentDetails != null)
                {
                    userName = SessionWrapper.PaymentDetails.userName;
                    orderID = SessionWrapper.PaymentDetails.orderID;
                    totalReportCost = SessionWrapper.PaymentDetails.totalReportCost;
                    discountOffered = SessionWrapper.PaymentDetails.discountOffered;
                    TransactionID = SessionWrapper.PaymentDetails.TransactionID;
                }


                if (SessionWrapper.ModuleName != Constant.UNCOVER_BACKGROUND)
                {
                    selectedProf = ProfessionHelper.GetProfessionNameById(SessionWrapper.OrderDetail.ProfessionId);
                    PlanPrice = PlanHelper.GetPlan(SessionWrapper.OrderDetail.PlanId).Rate;
                    Decimal discountRate = PlanHelper.GetPlan(SessionWrapper.OrderDetail.PlanId).RateOff;
                    List<EknowIDModel.Report> reports = PlanHelper.GetPlanReports(selectedPlanId);
                }
                else
                {
                    if (SessionWrapper.ResumeRuleCheck.isResumeModule == true)
                        selectedProf = ProfessionHelper.GetProfessionNameById(SessionWrapper.OrderDetail.ProfessionId);
                    else
                        selectedProf = Constant.UNCOVER_BACKGROUND;
                }

                Decimal OptionalReportsPrice = 0;

                decimal otherCharges = 0;

                if (SessionWrapper.AlacartReportList.Count != 0)
                {
                    List<int> alacartRptIDList = SessionWrapper.AlacartReportList;
                    Dictionary<int, int> alacartReportListWithQty = SessionWrapper.AlacartReportListWithQty;
                    List<Report> alacartReportList = new List<Report>();
                    Report report;

                    foreach (int reportID in alacartRptIDList)
                    {
                        var qty = (null != alacartReportListWithQty && alacartReportListWithQty.ContainsKey(reportID)) ? alacartReportListWithQty[reportID] : 1;
                        report = new Report();
                        report = PlanHelper.GetReportByReportID(reportID);
                        OptionalReportsPrice += (qty * report.Price.Value);
                        if ("Education Verification" == report.Name || "Employment Verification" == report.Name) {
                            otherCharges += (25 * qty);
                        }
                    }

                }

                string moduleName = SessionWrapper.ModuleName;
                moduleName = SessionWrapper.ResumeRuleCheck.isResumeModule == true ? Constant.RESUME_CHECKER : moduleName;
                otherCharges += SessionWrapper.AlacartAccessFees;
                accessFees = otherCharges.ToString("C");

                lblName.Text = userName;
                lblTransID.Text = TransactionID;
                lblOrdNo.Text = orderID.ToString();
                lblOptRptCost.Text = OptionalReportsPrice.ToString("C");
                lblDiscountOffer.Text = "- " + discountOffered.ToString("C");
                lblPurchaseDt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " + DateTime.Now.Date.ToString("dd") + " " + DateTime.Now.Year;
                lblTransAmount.Text = totalReportCost;
                lblSelectedProf.Text = selectedProf;
                lblModuleName.Text = moduleName;
                lblOtherCharges.Text = accessFees;
                if (SessionWrapper.ModuleName != Constant.UNCOVER_BACKGROUND)
                {
                    lblPackageName.Text = PlanHelper.GetPlan(selectedPlanId).Name.ToString();
                    lblRptCost.Text = PlanHelper.GetPlan(selectedPlanId).Rate.ToString("C");
                }

                //Payment Success mail to user
                StringBuilder emailBodyPayment = new StringBuilder(ConstructMail.GetMailBody(Constant.PAYMENT_COMPLETE));
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_FIRSTNAME, SessionWrapper.LoggedUser.FirstName);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_LASTNAME, SessionWrapper.LoggedUser.LastName);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_TRANSACTIONID, TransactionID);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_ORDERNUMBER, orderID.ToString());
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_PURCHASEDATE, lblPurchaseDt.Text);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_PACKAGENAME, lblPackageName.Text);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_PROFESSION, selectedProf);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_COSTOFREPORT, lblRptCost.Text);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_OPTIONALREPORT, OptionalReportsPrice.ToString("C"));
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_DISCOUNTOFFERED, lblDiscountOffer.Text);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_TRANSACTIONAMOUNT, totalReportCost);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_MODULENAME, moduleName);
                emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_OTHERCHARGES, accessFees);


                StringBuilder emailBodyPaymentSupport = new StringBuilder(ConstructMail.GetMailBody(Constant.PAYMENT_COMPLETE_SUPPORT));
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_FIRSTNAME, SessionWrapper.LoggedUser.FirstName);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_USEREMAILID, SessionWrapper.LoggedUser.Email);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_TRANSACTIONID, TransactionID);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_ORDERNUMBER, orderID.ToString());
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_PURCHASEDATE, lblPurchaseDt.Text);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_PACKAGENAME, lblPackageName.Text);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_PROFESSION, selectedProf);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_COSTOFREPORT, lblRptCost.Text);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_OPTIONALREPORT, OptionalReportsPrice.ToString("C"));
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_DISCOUNTOFFERED, lblDiscountOffer.Text);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_TRANSACTIONAMOUNT, totalReportCost);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_MODULENAME, moduleName);
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_OTHERCHARGES, accessFees);

                StringBuilder reportList = new StringBuilder("");
                List<string> lstReport = new List<string>();
                List<Report> reportNameList = PlanHelper.GetPlanReports(selectedPlanId);

                string reportName = string.Empty;
                foreach (Report report in reportNameList)
                {
                    reportName = report.Name;
                    lstReport.Add(reportName);

                }

                if (SessionWrapper.AlacartReportList.Count != 0)
                {
                    List<int> alacartRptIDList = SessionWrapper.AlacartReportList;
                    Report report;

                    foreach (int reportID in alacartRptIDList)
                    {
                        report = new Report();
                        report = PlanHelper.GetReportByReportID(reportID);
                        lstReport.Add(report.Name);
                    }
                }


                lstReport.Sort();
                reportList = reportList.Append("<ul>");

                for (int count = 0; count < lstReport.Count; count++)
                {
                    reportName = "<li>" + lstReport[count] + "</li>";
                    reportList = reportList.Append(reportName);
                }
                reportList = reportList.Append("</ul>");

                emailBodyPayment = emailBodyPayment.Replace("divReportList", reportList.ToString());
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace("divReportList", reportList.ToString());

                if (selectedProf == Constant.UNCOVER_BACKGROUND)
                {
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_SELECTPROFCLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_PACKAGENAMECLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_PACKAGECOSTCLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_ADDITIONALREPORTCOST, Constant.CONST_ALACARTREPORTCOST);

                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_SELECTPROFCLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_PACKAGENAMECLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_PACKAGECOSTCLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_ADDITIONALREPORTCOST, Constant.CONST_ALACARTREPORTCOST);

                    lblAddReportCost.Text = "Alacart Report(s) Cost:";
                }

                if (selectedProf == Constant.IDENTITY_THEFT)
                {
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_SELECTPROFCLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_SELECTPROFCLASS, Constant.CONST_DISPLAYNONECLASS);
                }

                if (moduleName == Constant.RESUME_CHECKER)
                {
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_PACKAGENAMECLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_PACKAGECOSTCLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPayment = emailBodyPayment.Replace(Constant.CONST_ADDITIONALREPORTCOST, Constant.CONST_ALACARTREPORTCOST);

                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_PACKAGENAMECLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_PACKAGECOSTCLASS, Constant.CONST_DISPLAYNONECLASS);
                    emailBodyPaymentSupport = emailBodyPaymentSupport.Replace(Constant.CONST_ADDITIONALREPORTCOST, Constant.CONST_ALACARTREPORTCOST);

                    lblAddReportCost.Text = "Alacart Report(s) Cost:";
                }

                if (SessionWrapper.PaymentDetails != null && SessionWrapper.PaymentDetails.isPaymentNotificationSend == false)
                {
                    SendMail.Sendmail(SessionWrapper.LoggedUser.Email, Constant.CONST_PAYMENT_SUCCESS, emailBodyPayment.ToString());
                    SendMail.Sendmail(Constant.ADMINEMAIL, Constant.CONST_PAYMENT_SUCCESS_SUPPORT, emailBodyPaymentSupport.ToString());

                    SessionWrapper.PaymentDetails.isPaymentNotificationSend = true;
                }
                if (moduleName == Constant.UNCOVER_BACKGROUND)
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setUncoverBg();", true);
                if (moduleName == Constant.IDENTITY_THEFT)
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setIDTheftBg();", true);
                if (moduleName == Constant.RESUME_CHECKER)
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setResumeCheckerBg();", true);
            }
            catch { }
        }

    }
}