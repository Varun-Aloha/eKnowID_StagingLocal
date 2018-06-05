using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDModel;
using EknowIDData.Helper;
using eknowID.AppCode;
using eknowID.Controls;
using System.Web.Services;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class RC_DetailedAnalysis :BasePage
    {
        public List<ResumeChecker_AlacartReport> alacartReportDispalyList;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
              
                RCAlacartReportList.DataSource = dispalyReport();
                RCAlacartReportList.DataBind();
            }
            SessionWrapper.RequiredInformation = new RequiredInformation();
            if (SessionWrapper.LoggedUser != null)
            {
                hdnUserLoggedIn.Value = "True";
            }
            else
            {
                hdnUserLoggedIn.Value = "False";
            }

            SessionWrapper.RequiredInformation = new RequiredInformation();
            //SessionWrapper.RequiredInformation.isEducationDetailsRequired = true;
            //SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = true;
            SessionWrapper.ModuleName = Constant.RESUME_CHECKER;
            SessionWrapper.OrderDetail = new OrderDetails();
          
        }

        List<ResumeChecker_AlacartReport> dispalyReport()
        {
            List<ResumeChecker_AlacartReport> alacartReports = new List<ResumeChecker_AlacartReport>();
            string[] alacartReportList = { "eKnowID Criminal MultiState Check", "Employment Verification", "Education Verification", "IDentify" };
            List<Report> reportLst = PlanHelper.GetAlacartReportList();
            ResumeChecker_AlacartReport alacartReport;
            foreach (string reportName in alacartReportList)
            {
                foreach (Report report in reportLst)
                {
                    if (report.Name == reportName)
                    {
                        alacartReport = new ResumeChecker_AlacartReport();
                        alacartReport.report = new Report();
                        alacartReport.report.Name = report.Name;
                        alacartReport.report.Description = report.Description;
                        alacartReport.report.Price = report.Price;
                        alacartReport.report.ReportId = report.ReportId;
                        alacartReport.report.TurnaroundTime = report.TurnaroundTime;
                        alacartReport.report.reportShortDesrript = report.reportShortDesrript;
                        alacartReports.Add(alacartReport);
                        break;
                    }
                }
            }

            return alacartReports;
        }

        protected void RCAlacartReportList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ResumeChecker_AlacartReport alacartReportDisplay = e.Item.DataItem as ResumeChecker_AlacartReport;
                UserControl control = e.Item.FindControl("ucRCAlarte") as UserControl;
                ManipulateReportDisplay(alacartReportDisplay.report, control);
            }
        }

        private static void ManipulateReportDisplay(Report reportData, UserControl control)
        {

            if (reportData != null)
            {
                eknowID.Controls.ResumeChecking_AlaCartReport alacartReport = control as eknowID.Controls.ResumeChecking_AlaCartReport;
                if (alacartReport != null)
                {
                    alacartReport.report = reportData;
                }
            }
            else
            {
                eknowID.Controls.AlaCartReport alacartReport = control as eknowID.Controls.AlaCartReport;
                if (alacartReport != null)
                {
                    alacartReport.Visible = false;
                }
            }
        }     

    }
    public class ResumeChecker_AlacartReport
    {
        public Report report { get; set; }
    }
}