using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDModel;
using EknowIDData.Helper;
using EknowIDLib;
using eknowID.AppCode;
using System.Web.Services;

namespace eknowID.Pages
{
    public partial class SelectProf_PackageSelection : System.Web.UI.Page
    {
        private static List<Report> basicReportList;
        private static List<Report> goldReportList;
        private static List<Report> PlatinumReportList;
        private static int basicPlanId;
        private static int GoldPlanId;
        private static int PlatniumPlanId;

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.OrderDetail = null;
            SessionWrapper.OrderDetail = new OrderDetails();
            SessionWrapper.OrderDetail.ProfessionId = 33;
            SessionWrapper.ModuleName = Constant.IDENTITY_THEFT;

            if (SessionWrapper.LoggedUser != null)
            {
                hdnUserLoggedIn.Value = "True";
            }
            else
            {
                hdnUserLoggedIn.Value = "False";
            }

            if (SessionWrapper.OrderDetail == null || SessionWrapper.OrderDetail.ProfessionId == 0)
            {
                Response.Redirect("SearchByProf_SelectProf.aspx");
            }


            //if (SessionWrapper.ModuleName == Constant.SECURE_JOB)
            //{
                ucSearchHeader.Visible = true;
                //IdentityTheft_SearchByRef.Visible = false;

                Label lblPackageSelection = ucSearchHeader.FindControl("lblSelectProfession") as Label;
                lblPackageSelection.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

                Image imgBtnPackageSelection = ucSearchHeader.FindControl("imgBtnDot1") as Image;
                imgBtnPackageSelection.ImageUrl = "~/Images/color_hover_round.png";

                Label lblSearchByProf = ucSearchHeader.FindControl("lblSelectByProf") as Label;
                lblSearchByProf.Text = "Package Selection";
            //}
            //else
            //{   ucSearchHeader.Visible = false;
            //    IdentityTheft_SearchByRef.Visible = true;

            //    Label lblPackageSelection = IdentityTheft_SearchByRef.FindControl("lblChoosePlan") as Label;
            //    lblPackageSelection.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

            //    Image imgBtnPackageSelection = IdentityTheft_SearchByRef.FindControl("imgBtnDot2") as Image;
            //    imgBtnPackageSelection.ImageUrl = "~/Images/color_hover_round.png";

            //    Label lblSearchByProf = IdentityTheft_SearchByRef.FindControl("lblSelectByProf") as Label;
            //    lblSearchByProf.Text = "Package Selection";
            //}

            

            if (!IsPostBack)
            {
                basicReportList = new List<Report>();
                goldReportList = new List<Report>();
                PlatinumReportList = new List<Report>();

                grvCriminalReports.DataSource = setCriminalPlanData(Constant.CRIMINAL_REPORT_TYPE);
                grvCriminalReports.DataBind();

                grvVerificationReports.DataSource = setCriminalPlanData(Constant.VERIFICATION_REPORT_TYPE);
                grvVerificationReports.DataBind();

                //grvMiscellaneous.DataSource = setCriminalPlanData(Constant.MISCELLANEOUS_REPORT_TYPE);
                //grvMiscellaneous.DataBind();
            }
        }

        private List<ReportData> setCriminalPlanData(int reportTypeID)
        {
            int professionID = SessionWrapper.OrderDetail.ProfessionId;



            Report requireReportData;
            List<ReportData> ReportList = new List<ReportData>();

            ReportData ReportData;
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
                ReportData = new ReportData();
                ReportData.Name = report.Name;
                ReportData.Description = report.Description;
                ReportData.TurnaroundTime ="("+ report.TurnaroundTime+")";
                ReportData.Basic = false;
                ReportData.Gold = false;
                ReportData.Platinum = false;

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
            return ReportList;
        }

        private List<ReportData> setPlanData(int reportTypeID)
        {
            int professionID = SessionWrapper.OrderDetail.ProfessionId;
            string[] requiredReport = { "Employment Verification", "Education Verification", "Reference Verification", "Driving Record", "KnowID Drug Test" };
            List<ReportData> ReportList = new List<ReportData>();

            Report requireReportData;
            ReportData ReportData;
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
                ReportData = new ReportData();
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

        //protected void imgBasicContinue_Click(object sender, ImageClickEventArgs e)
        //{
        //    ImageButton btn = (ImageButton)sender;

        //    SessionWrapper.OrderDetail = new OrderDetails();

        //    if (btn.ID == "imgBasicContinue")
        //    {
        //        SessionWrapper.OrderDetail.PlanId = basicPlanId;
        //    }
        //    else if (btn.ID == "imgGoldContinue")
        //    {
        //        SessionWrapper.OrderDetail.PlanId = GoldPlanId;
        //    }
        //    else if (btn.ID == "imgPlatniumContinue")
        //    {
        //        SessionWrapper.OrderDetail.PlanId = PlatniumPlanId;
        //    }

        //    List<Report> reports = PlanHelper.GetPlanReports(SessionWrapper.OrderDetail.PlanId);


        //    SessionWrapper.RequiredInformation = null;
        //    SessionWrapper.RequiredInformation = new RequiredInformation();
        //    SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = reports.IsEmpInfoRequired();
        //    SessionWrapper.RequiredInformation.isEducationDetailsRequired = reports.IsEduInfoRequired();
        //    SessionWrapper.RequiredInformation.isLicenseInformationRequired = reports.IsLicInfoRequired();
        //    SessionWrapper.RequiredInformation.isReferenceInformationRequired = reports.IsRefInfoRequired();
        //    SessionWrapper.RequiredInformation.isDrugVerificationRequired = reports.IsDrugVerificationRequired();

        //    SessionWrapper.ModuleName = Constant.IDENTITY_THEFT;
        //    SessionWrapper.OrderDetail.ProfessionId = 33;

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "AnUniqueKey", "redirectToUpgradePackage();", true);


        //}

        [WebMethod]
        public static void SetAdditionalInfoRequire(string planName)
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

            SessionWrapper.ModuleName = Constant.IDENTITY_THEFT;
            SessionWrapper.OrderDetail.ProfessionId = 33;         
        }
    }

    public class ReportData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TurnaroundTime { get; set; }
        public bool Basic { get; set; }
        public bool Gold { get; set; }
        public bool Platinum { get; set; }
    }
}