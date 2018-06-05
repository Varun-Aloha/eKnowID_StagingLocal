using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDData.Helper;
using System.Globalization;
using System.Text;
using EknowIDLib;
using EknowIDModel;

namespace eknowID.Controls
{
    public partial class completePurchase : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetSummaryData(string userName, string TransactionID, int orderID, string totalReportCost, string discountOffered)
        {
            //Show payment summary
            int selectedPlanId = SessionWrapper.OrderDetail.PlanId;
            string selectedProf; 
            Decimal PlanPrice=0;
            if (SessionWrapper.ModuleName != Constant.UNCOVER_BACKGROUND)
            {
                selectedProf = ProfessionHelper.GetProfessionNameById(SessionWrapper.OrderDetail.ProfessionId);
                PlanPrice = PlanHelper.GetPlan(SessionWrapper.OrderDetail.PlanId).Rate;
                Decimal discountRate = PlanHelper.GetPlan(SessionWrapper.OrderDetail.PlanId).RateOff;
                List<EknowIDModel.Report> reports = PlanHelper.GetPlanReports(selectedPlanId);
            }
            else
                selectedProf = Constant.UNCOVER_BACKGROUND;

          
            Decimal OptionalReportsPrice = 0;          
          

            if (SessionWrapper.AlacartReportList.Count != 0)
            {
                List<int> alacartRptIDList = SessionWrapper.AlacartReportList;

                List<Report> alacartReportList = new List<Report>();
                Report report;

                foreach (int reportID in alacartRptIDList)
                {
                    report = new Report();
                    report = PlanHelper.GetReportByReportID(reportID);
                    OptionalReportsPrice += report.Price.Value;

                }

            }
            lblName.Text = userName;
            lblTransID.Text = TransactionID;
            lblOrdNo.Text = orderID.ToString();           
            lblOptRptCost.Text = OptionalReportsPrice.ToString("C");
            lblDiscountOffer.Text = "- " + discountOffered;
            lblPurchaseDt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " + DateTime.Now.Date.ToString("dd") + " " + DateTime.Now.Year;
            lblTransAmount.Text = totalReportCost;
            lblSelectedProf.Text = selectedProf;

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

            StringBuilder reportList = new StringBuilder("");
            List<string> lstReport = new List<string>();
            //lstReport = OrderStatusHelper.GetReportList(orderID);
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

            if (selectedProf != Constant.UNCOVER_BACKGROUND)
            {
                emailBodyPayment = emailBodyPayment.Replace("display:none;", "");
                emailBodyPaymentSupport = emailBodyPaymentSupport.Replace("display:none;", "");
            }


            SendMail.Sendmail(SessionWrapper.LoggedUser.Email, Constant.CONST_PAYMENT_SUCCESS, emailBodyPayment.ToString());

            SendMail.Sendmail(Constant.ADMINEMAIL,Constant.CONST_PAYMENT_SUCCESS_SUPPORT,emailBodyPaymentSupport.ToString());

            if (SessionWrapper.ModuleName == Constant.UNCOVER_BACKGROUND)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setUncoverBg();", true);
            }
        }
    }
}