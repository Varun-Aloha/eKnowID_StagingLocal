using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using EknowIDModel;
using System.Web.Services;
using eknowID.AppCode;
using EknowIDLib;
using EknowIDData.Helper;

namespace eknowID.Pages
{
    public partial class SearchByProf_SelectProf : BasePage
    {
        protected static int professionID;
        private static List<Report> basicReportList;
        private static List<Report> goldReportList;
        private static List<Report> PlatinumReportList;
        private static int basicPlanId; 
        private static int GoldPlanId;
        private static int PlatniumPlanId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.OrderDetail = null;
                SessionWrapper.ModuleName = Constant.SECURE_JOB;

                PopulateProfessions();
                if (SessionWrapper.OrderDetail != null && SessionWrapper.OrderDetail.ProfessionId > 0)
                {
                    ddlProfession.SelectedValue = SessionWrapper.OrderDetail.ProfessionId.ToString();
                }
             
            }

            Label lblSearchByProf = ucSearchHeader.FindControl("lblSelectProfession") as Label;
            lblSearchByProf.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

            Image imgBtnSelectProf = ucSearchHeader.FindControl("imgBtnDot1") as Image;
            imgBtnSelectProf.ImageUrl = "~/Images/color_hover_round.png";

            if (SessionWrapper.LoggedUser != null)
            {
                hdnUserLoggedIn.Value = "True";
            }
            else
            {
                hdnUserLoggedIn.Value = "False";
            }

        }

      
        private void PopulateProfessions()
        {
            ISpecification<Profession> professionSpc = new Specification<Profession>(p => p.ProfessionId != Constant.ID_THEFT_PROFID && p.ProfessionId != Constant.UNCOVER_BACKGROUND_PROFID);
            IRepository<Profession> profRepository = new Repository<Profession>();
            IList<Profession> professionList = profRepository.SelectAll(professionSpc);

            ddlProfession.DataTextField = "Name";
            ddlProfession.DataValueField = "ProfessionId";
            ddlProfession.DataSource = professionList.OrderBy(o => o.Name);
            ddlProfession.DataBind();

            ddlProfession.Items.Insert(0, new ListItem("Select", "0"));
            ddlProfession.SelectedIndex = 0;
        }

        private List<PlanReportData>setCriminalPlanData(int reportTypeID)
        {
            int professionID = SessionWrapper.OrderDetail.ProfessionId;
            
            Report requireReportData;
            List<PlanReportData> ReportList = new List<PlanReportData>();

            PlanReportData ReportData;
            List<Report> reports = PlanHelper.GetReportListByReportTypeId(reportTypeID);
            List<ReportList> PlanIdList = PlanHelper.GetPlanID(professionID);

            String[] strVal = String.Format("{0:0.00}", PlanIdList[0].Rate).Split(new char[] { '.' }, StringSplitOptions.None);
            lblBasicPrice.Text = strVal[0] + "." + strVal[1];
            hdnBasicPlanID.Value = PlanIdList[0].PlanID.ToString();
            basicPlanId = PlanIdList[0].PlanID;

            strVal = String.Format("{0:0.00}", PlanIdList[1].Rate).Split(new char[] { '.' }, StringSplitOptions.None);
            lblGoldPrice.Text = strVal[0] + "." + strVal[1];
            hdnGoldPlanID.Value = PlanIdList[1].PlanID.ToString();
            GoldPlanId = PlanIdList[1].PlanID;

            strVal = String.Format("{0:0.00}", PlanIdList[2].Rate).Split(new char[] { '.' }, StringSplitOptions.None);
            lblPlatniumPrice.Text = strVal[0] + "." + strVal[1];
            hdnPlatinumPlanID.Value = PlanIdList[2].PlanID.ToString();
            PlatniumPlanId = PlanIdList[2].PlanID;

            foreach (Report report in reports)
            {

                requireReportData = new Report();
                ReportData = new PlanReportData();
                ReportData.Name = report.Name;
                ReportData.Description = report.Description;
                ReportData.TurnaroundTime = "(" + report.TurnaroundTime + ")";
                ReportData.Basic = false;
                ReportData.Gold = false;
                ReportData.Platinum = false;
                ReportData.Resume = false;

                if (PlanIdList[0].ReportNameList.Contains(report.Name))
                {
                    ReportData.Basic = true;
                    requireReportData.Name = report.Name;
                    basicReportList.Add(requireReportData);


                }

                if (PlanIdList[1].ReportNameList.Contains(report.Name))
                {
                    ReportData.Gold = true;
                    requireReportData.Name = report.Name;
                    goldReportList.Add(requireReportData);
                }
                if (PlanIdList[2].ReportNameList.Contains(report.Name))
                {
                    ReportData.Platinum = true;
                    requireReportData.Name = report.Name;
                    PlatinumReportList.Add(requireReportData);
                }
                if (ReportData.Basic == true || ReportData.Gold == true || ReportData.Platinum == true)
                {
                    ReportList.Add(ReportData);
                }              
            }
            if (reportTypeID == Constant.MISCELLANEOUS_REPORT_TYPE)
            {
                Report ResumeCheckerReport = PlanHelper.GetReportByReportID(Constant.RESUMECHECKER_REPORT_ID);
                PlanReportData PlanReportData = new Pages.PlanReportData();
                PlanReportData.Resume = true;
                PlanReportData.Name = ResumeCheckerReport.Name;
                PlanReportData.Description = ResumeCheckerReport.Description;
                PlanReportData.TurnaroundTime = "(" + ResumeCheckerReport.TurnaroundTime + ")";
                ReportList.Add(PlanReportData);
            }

            return ReportList;
        }

        private List<PlanReportData> setPlanData(int reportTypeID)
        {
            int professionID = SessionWrapper.OrderDetail.ProfessionId;
            string[] requiredReport = { "Employment Verification", "Education Verification", "Reference Verification", "Driving Record", "KnowID Drug Test" };
            List<PlanReportData> ReportList = new List<PlanReportData>();

            Report requireReportData;
            PlanReportData ReportData;
            List<Report> reports = PlanHelper.GetReportListByReportTypeId(reportTypeID);
            List<Report> professioReportLists = PlanHelper.GetReportList(professionID, reportTypeID);

            foreach (string reportName in requiredReport)
            {
                foreach (Report profReportList in professioReportLists)
                {
                    if (profReportList.Name == reportName)
                    {
                        if (hdnRequiredReport.Value == string.Empty)
                        {
                            hdnRequiredReport.Value = profReportList.Name;
                        }
                        else
                        {
                            hdnRequiredReport.Value = hdnRequiredReport.Value + "," + profReportList.Name;
                        }
                    }

                }
            }

            foreach (Report report in reports)
            {
                requireReportData = new Report();
                ReportData = new PlanReportData();
                ReportData.Name = report.Name;
                ReportData.Basic = false;

                foreach (Report profReportList in professioReportLists)
                {
                    if (profReportList.Name == report.Name)
                    {
                        ReportData.Basic = true;
                        requireReportData.Name = report.Name;
                        basicReportList.Add(requireReportData);
                        goldReportList.Add(requireReportData);
                        PlatinumReportList.Add(requireReportData);
                    }

                }

                ReportList.Add(ReportData);
            }
            return ReportList;
        }       

        protected void btnChooseReport_Click(object sender, EventArgs e)
        {

        }

        protected void ddlProfession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SessionWrapper.OrderDetail == null)
                SessionWrapper.OrderDetail = new OrderDetails();
            // = int.Parse(hdnProfessionId.Value);

            int professionId =int.Parse(ddlProfession.SelectedValue);
            if (professionId != 0)
            {
                SessionWrapper.OrderDetail.ProfessionId = professionId;
                IRepository<Profession> profRepository = new Repository<Profession>("ProfessionId");
                Profession profession = profRepository.SelectByKey(professionId.ToString());

                basicReportList = new List<Report>();
                goldReportList = new List<Report>();
                PlatinumReportList = new List<Report>();

                grvCriminalReports.DataSource = setCriminalPlanData(Constant.CRIMINAL_REPORT_TYPE);
                grvCriminalReports.DataBind();

                grvVerificationReports.DataSource = setCriminalPlanData(Constant.VERIFICATION_REPORT_TYPE);
                grvVerificationReports.DataBind();

                //grvMiscellaneous.DataSource = setCriminalPlanData(Constant.MISCELLANEOUS_REPORT_TYPE);
                //grvMiscellaneous.DataBind();

                ProfessionDescription.InnerText = profession.Description;
                ProfessionDescription.Visible = true;
                lblErrorSelectProf.Visible = false;
                descriptionHeader.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "showPackages();", true);
            }
            else
            {
                lblErrorSelectProf.Visible = true;
                descriptionHeader.Visible = false;
                ProfessionDescription.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "hidePackages();", true);
            }
        }

        protected void imgBtnResumeAnalysis_Click(object sender, ImageClickEventArgs e)
        {

        }      

        [WebMethod]
        public static void SetAdditionalInfoRequire(string planName, int professionId)
        {
           
            SessionWrapper.OrderDetail = new OrderDetails();

            if (planName == "Basic")
            {
                SessionWrapper.OrderDetail.PlanId = basicPlanId;
            }
            else if (planName == "Gold")
            {
                SessionWrapper.OrderDetail.PlanId = GoldPlanId;
            }
            else if (planName == "Platnium")
            {
                SessionWrapper.OrderDetail.PlanId = PlatniumPlanId;
            }

            List<Report> reports = PlanHelper.GetPlanReports(SessionWrapper.OrderDetail.PlanId);

            SessionWrapper.RequiredInformation = null;
            SessionWrapper.RequiredInformation = new RequiredInformation();
            SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = reports.IsEmpInfoRequired();
            SessionWrapper.RequiredInformation.isEducationDetailsRequired = reports.IsEduInfoRequired();
            SessionWrapper.RequiredInformation.isLicenseInformationRequired = reports.IsLicInfoRequired();
            SessionWrapper.RequiredInformation.isReferenceInformationRequired = reports.IsRefInfoRequired();
            SessionWrapper.RequiredInformation.isDrugVerificationRequired = reports.IsDrugVerificationRequired();

           
            if (professionId != 0)
            {
                SessionWrapper.OrderDetail.ProfessionId = professionId;
            }

            SessionWrapper.ModuleName = Constant.SECURE_JOB;
        }

    }

    public class PlanReportData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TurnaroundTime { get; set; }
        public bool Basic { get; set; }
        public bool Gold { get; set; }
        public bool Platinum { get; set; }
        public bool Resume { get; set; }
    }
}
