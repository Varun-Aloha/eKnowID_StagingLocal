using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDModel;
using eknowID.AppCode;
using EknowIDData.Helper;
using System.Web.Services;
using EknowIDLib;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using System.Text;

namespace eknowID.Pages
{
    public partial class UpgradeReportPackage : BasePage
    {
        public List<UpgradeReportDisplay> alacartReportDispalyList;
        public static string ModuleName;
        public static int PlanId;
        public static int ProfId;
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                CriminalAlacartReportList.DataSource = dispalyReport(Constant.CRIMINAL_REPORT_TYPE);
                CriminalAlacartReportList.DataBind();
                VerificationAlacartReportList.DataSource = dispalyReport(Constant.VERIFICATION_REPORT_TYPE);
                VerificationAlacartReportList.DataBind();
                MiscellaneousAlacartReportList.DataSource = dispalyReport(Constant.MISCELLANEOUS_REPORT_TYPE);
                MiscellaneousAlacartReportList.DataBind();

                ModuleName = SessionWrapper.ModuleName;
                PlanId = SessionWrapper.OrderDetail.PlanId!=null?SessionWrapper.OrderDetail.PlanId:0;
                ProfId = SessionWrapper.OrderDetail.ProfessionId!=null?SessionWrapper.OrderDetail.ProfessionId:0;
            }
            //SessionWrapper.RequiredInformation = new RequiredInformation();
            if (SessionWrapper.LoggedUser != null)
            {
                hdnUserLoggedIn.Value = "True";
            }
            else
            {
                hdnUserLoggedIn.Value = "False";
            }

            Label lblSearchByProf = ucSearchHeader.FindControl("lblChoosePlan") as Label;
            lblSearchByProf.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

            Image imgBtnSelectProf = ucSearchHeader.FindControl("imgBtnDot2") as Image;
            imgBtnSelectProf.ImageUrl = "~/Images/color_hover_round.png";

            Label lblPageHeader = ucSearchHeader.FindControl("lblSelectByProf") as Label;
            lblPageHeader.Text = "Upgrade Package";
            GetStateCriminalAccessFeesList();
            GetFederalCriminalAccessFeesList();
            GetCountyCriminalAccessFeesList();
        }

        private void GetStateCriminalAccessFeesList() {
            if (ddlStates.Items.Count == 0) {
                IRepository<EknowIDModel.StateCriminalCourtFee> state_criminal = new Repository<EknowIDModel.StateCriminalCourtFee>();
                IList<EknowIDModel.StateCriminalCourtFee> stateList = state_criminal.SelectAll().Where(p => !p.Availability.Trim().ToLower().Equals("not available")).ToList(); ;
                //ddlStates.DataTextField = "Name";
                //ddlStates.DataValueField = "Fee";
                //ddlStates.DataSource = stateList;
                //ddlStates.DataBind();

                //ddlStates.Items.Insert(0, new ListItem("Select State", "0"));
                //ddlStates.SelectedIndex = 0;

                StringBuilder output = new StringBuilder();

                foreach (var state in stateList) {
                    string colorStyle = state.Availability.Trim().Equals("Available") ? "black" : "red";
                    output.AppendFormat("<li style=\"background: none;margin-bottom: 0px;padding: 0px;margin: 0px;background-color: #e5e5e5;\"><a style=\"color:{4}\" href = \"#\" class=\"small\" data-stateid=\"{3}\" data-value=\"{0}\" tabindex=\"-1\"><input type = \"checkbox\" /> &nbsp; {1}&nbsp;({2}) </a></li>", state.Fee, state.Name, state.TurnAroundTime, state.AlphaCode, colorStyle);
                }
                hdnStateCriminalList.Value = output.ToString();
            }
        }

        private void GetFederalCriminalAccessFeesList() {
            if (ddlStates.Items.Count == 0) {
                IRepository<EknowIDModel.StateDistrictCourtFee> state_district = new Repository<EknowIDModel.StateDistrictCourtFee>();
                IRepository<EknowIDModel.State> states = new Repository<EknowIDModel.State>();

                var districtList = (from c in state_district.SelectAll()
                                    join s in states.SelectAll()
                                    on c.StateId equals s.StateId
                                    select new {
                                        c.StateId,
                                        c.Id,
                                        c.DistrictCourtFees,
                                        s.Name,
                                        c.DistrictCourt
                                    }).GroupBy(p => p.StateId);

                StringBuilder output = new StringBuilder();

                foreach (var stateDistricts in districtList) {
                    var state = stateDistricts.FirstOrDefault().Name;
                    output.AppendFormat("<li style =\"background: none;margin-bottom: 0px;padding-left: 5px;margin: 0px;background-color: #e5e5e5;\">{0}</li>" +
                        "<ul style=\"overflow:auto; background-color:#e5e5e5 !important; left:100px; padding:0px;\">", state);
                    foreach (var district in stateDistricts) {
                        string colorStyle = "black"; //state.Availability.Trim().Equals("Available") ? "black" : "red";
                        output.AppendFormat("<li style=\"background: none;margin-bottom: 0px;padding: 0px;margin: 0px;background-color: #e5e5e5;\"><a style=\"color:{4}\" href = \"#\" class=\"small\" data-federalid=\"{3}\" data-value=\"{0}\" tabindex=\"-1\"><input type = \"checkbox\" /> &nbsp; {1}&nbsp;({2}) </a></li>", district.DistrictCourtFees, state + " " + district.DistrictCourt + "District Court", district.Id, district.Id, colorStyle);
                    }
                    output.AppendFormat("</ul>");
                }
                hdnFederalCriminalList.Value = output.ToString();
            }
        }

        private void GetCountyCriminalAccessFeesList() {
            if (ddlStates.Items.Count == 0) {
                IRepository<EknowIDModel.StateCountyCourtFee> state_county = new Repository<EknowIDModel.StateCountyCourtFee>();
                IRepository<EknowIDModel.State> states = new Repository<EknowIDModel.State>();

                var countyList = (from c in state_county.SelectAll()
                                  join s in states.SelectAll()
                                  on c.StateId equals s.StateId
                                  select new {
                                      c.StateId,
                                      c.Id,
                                      c.CircuitCourtFees,
                                      c.DistrictCourtFees,
                                      c.County,
                                      s.Name,
                                      c.IsYearly,
                                      c.PerRecordFees,
                                  }).GroupBy(p => p.StateId);

                //ddlStates.DataTextField = "Name";
                //ddlStates.DataValueField = "Fee";
                //ddlStates.DataSource = stateList;
                //ddlStates.DataBind();

                //ddlStates.Items.Insert(0, new ListItem("Select State", "0"));
                //ddlStates.SelectedIndex = 0;

                StringBuilder output = new StringBuilder();

                foreach (var stateCounties in countyList) {
                    var state = stateCounties.FirstOrDefault().Name;
                    output.AppendFormat("<li class=\"liParent\" style =\"background: none;margin-bottom: 0px;padding-left: 5px;margin: 0px;background-color: #e5e5e5;\">{0}" +
                        "<ul style=\"overflow:auto; background-color:#e5e5e5 !important; left:100px; padding:0px;\">", state);
                    foreach (var county in stateCounties) {
                        string colorStyle = "black"; //state.Availability.Trim().Equals("Available") ? "black" : "red";
                        output.AppendFormat("<li class=\"liChild\" style=\"background: none;margin-bottom: 0px;padding: 0px;margin: 0px;background-color: #e5e5e5;\"><a style=\"color:{4}\" href = \"#\" class=\"small\" data-countyid=\"{3}\" data-value=\"{0}\" tabindex=\"-1\"><input class=\"chk_{2}\" type = \"checkbox\" /> &nbsp; {1}&nbsp;({2}) </a></li>", county.DistrictCourtFees, (string.IsNullOrEmpty(county.County) ? "All Counties" : county.County), county.Id, county.Id, colorStyle);
                    }
                    output.AppendFormat("</ul></li>");
                }
                hdnCountyCriminalList.Value = output.ToString();
                hdnCountyCivilList.Value = output.ToString();
            }
        }

        List<UpgradeReportDisplay> dispalyReport(int reportTypeId)
        {
            List<UpgradeReportDisplay> alacartReports = new List<UpgradeReportDisplay>();
            List<int> planReportId = PlanHelper.GetPlanReports(SessionWrapper.OrderDetail.PlanId).Select(p => p.ReportId).ToList();

            //string[] alacartReportList = {"County Criminal Courthouse Search", "Federal Criminal Courthouse Search", "International Criminal Record Search", "Employment Verification", "Education Verification", "IDentify", "Reference Verification", "eKnowID Drug Test", "Driving Record", "Credit", "County Civil Courthouse Search", "State Criminal Records", "Credit Report", "Global Security Watch List" };

            alacartReports = PlanHelper.GetAlacartReportList().Where(p => p.ReportTypeID == reportTypeId && p.IsActive &&
                                    (p.MaxVerificationCount > 1 || !planReportId.Contains(p.ReportId)))
                                    .Select(p => new UpgradeReportDisplay {
                                        report = new Report {
                                            Name = p.Name,
                                            Description = p.Description,
                                            Price = p.Price,
                                            ReportId = p.ReportId,
                                            TurnaroundTime = p.TurnaroundTime,
                                            IsMultipleCheckEnabled = p.IsMultipleCheckEnabled,
                                            MaxVerificationCount = p.MaxVerificationCount
                                        }
                                    }).ToList();            
            return alacartReports;
        }

        protected void alacartReportList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                UpgradeReportDisplay UpgradeReportDisplay = e.Item.DataItem as UpgradeReportDisplay;
                UserControl control = e.Item.FindControl("AlacartReport") as UserControl;
                ManipulateReportDisplay(UpgradeReportDisplay.report, control);
            }
        }

        private static void ManipulateReportDisplay(Report reportData, UserControl control)
        {

            if (reportData != null)
            {
                eknowID.Controls.AlaCartReport alacartReport = control as eknowID.Controls.AlaCartReport;
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

        [WebMethod]
        public static void SetSelectedAlacartReportList(string alacartReportList, string alacartReportQty, string selectedStates, string selectedDistricts, string selectedCounties, string selectedCivilCounties, decimal? stateAccessFees, decimal? holdingFees)
        {

            List<Report> reports = PlanHelper.GetPlanReports(PlanId);            


            SessionWrapper.RequiredInformation = null;
            SessionWrapper.RequiredInformation = new RequiredInformation();
            SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = reports.IsEmpInfoRequired();
            SessionWrapper.RequiredInformation.isEducationDetailsRequired = reports.IsEduInfoRequired();
            SessionWrapper.RequiredInformation.isLicenseInformationRequired = reports.IsLicInfoRequired();
            SessionWrapper.RequiredInformation.isReferenceInformationRequired = reports.IsRefInfoRequired();
            SessionWrapper.RequiredInformation.isDrugVerificationRequired = reports.IsDrugVerificationRequired();
            SessionWrapper.AlacartReportList = new List<int>();
            SessionWrapper.AlacartReportListWithQty = new Dictionary<int, int>();
            SessionWrapper.AlacartAccessFees = 0;
            SessionWrapper.HoldingFees = 0;
            SessionWrapper.SelectedStates = "";
            SessionWrapper.SelectedDistricts = "";
            SessionWrapper.SelectedCounties = "";
            SessionWrapper.SelectedCivilCounties = "";

            if (!string.IsNullOrEmpty(alacartReportList))
            {                
                SessionWrapper.AlacartAccessFees = (decimal)(stateAccessFees ?? 0);
                SessionWrapper.SelectedStates = selectedStates;
                SessionWrapper.SelectedDistricts = selectedDistricts;
                SessionWrapper.SelectedCounties = selectedCounties;
                SessionWrapper.SelectedCivilCounties = selectedCivilCounties;
                SessionWrapper.HoldingFees = (decimal)(holdingFees ?? 0);

                int reportID;
                int qty;
                string[] reportIdList = alacartReportList.Split(',');
                string[] qtyList = string.IsNullOrEmpty(alacartReportQty) ? null : alacartReportQty.Split(',');
                int i = 0;
                foreach (string reportId in reportIdList)
                {
                    reportID = int.Parse(reportId);
                    qty = (null == qtyList) ? 1 : int.Parse(qtyList[i]);
                    i++;

                    SessionWrapper.AlacartReportList.Add(reportID);
                    SessionWrapper.AlacartReportListWithQty.Add(reportID, qty);

                    if (reportID == Constant.EDUCATION_REPORT_ID)
                        SessionWrapper.RequiredInformation.isEducationDetailsRequired = true;
                    if (reportID == Constant.EMPLOYEE_REPORT_ID)
                        SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = true;
                    if (reportID == Constant.REFERENCE_REPORT_ID)
                        SessionWrapper.RequiredInformation.isReferenceInformationRequired = true;
                    if (reportID == Constant.LICENSE_REPORT_ID)
                        SessionWrapper.RequiredInformation.isLicenseInformationRequired = true;
                    if (reportID == Constant.DRUG_REPORT_ID)
                        SessionWrapper.RequiredInformation.isDrugVerificationRequired = true;
                }
            }            

            SessionWrapper.ModuleName = ModuleName;

            if(ProfId!=0)
            SessionWrapper.OrderDetail.ProfessionId = ProfId;

            if (PlanId != 0)
            SessionWrapper.OrderDetail.PlanId = PlanId;
        }

        [WebMethod]
        public static void SetAdditionalInfoRequire()
        {
            SessionWrapper.RequiredInformation = new RequiredInformation(); 
            List<Report> reports = PlanHelper.GetPlanReports(SessionWrapper.OrderDetail.PlanId);
            List<int> requireReports=new List<int>();
            int reportId;
            foreach(Report report in reports)
            {
                reportId=report.ReportId;
                requireReports.Add(reportId);
            }

            if(SessionWrapper.AlacartReportList.Contains(Constant.EDUCATION_REPORT_ID) || requireReports.Contains(Constant.EDUCATION_REPORT_ID))
            SessionWrapper.RequiredInformation.isEducationDetailsRequired =   true ;

            if (SessionWrapper.AlacartReportList.Contains(Constant.EMPLOYEE_REPORT_ID) || requireReports.Contains(Constant.EMPLOYEE_REPORT_ID))
            SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = true;

            if (SessionWrapper.AlacartReportList.Contains(Constant.REFERENCE_REPORT_ID) || requireReports.Contains(Constant.REFERENCE_REPORT_ID))
            SessionWrapper.RequiredInformation.isReferenceInformationRequired =true ;

            if (SessionWrapper.AlacartReportList.Contains(Constant.LICENSE_REPORT_ID) || requireReports.Contains(Constant.LICENSE_REPORT_ID))
            SessionWrapper.RequiredInformation.isLicenseInformationRequired = true;

            if (SessionWrapper.AlacartReportList.Contains(Constant.DRUG_REPORT_ID) || requireReports.Contains(Constant.DRUG_REPORT_ID))
            SessionWrapper.RequiredInformation.isDrugVerificationRequired = true;           

        }

        protected void btnChooseReport_Click(object sender, EventArgs e)
        {
            planOrderSummary.showPlanSummary();
        }

    }
    public class UpgradeReportDisplay
    {
        public Report report { get; set; }
    }
}