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
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using System.Text;

namespace eknowID.Pages
{
    public partial class AlacartReport : BasePage
    {
        public List<AlacartReportDisplay> alacartReportDispalyList;
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

                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "disableNextBtn();", true);
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

            Label lblSearchByProf = ucSearchHeader.FindControl("lblSelectByProf") as Label;
            lblSearchByProf.Text = "Select Reports";

            Label lblImport = ucSearchHeader.FindControl("lblChoosePlan") as Label;
            lblImport.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

            Image imgBtnImport = ucSearchHeader.FindControl("imgBtnDot2") as Image;
            imgBtnImport.ImageUrl = "~/Images/color_hover_round.png";

            SessionWrapper.OrderDetail = null;
            SessionWrapper.OrderDetail = new OrderDetails();
            SessionWrapper.ModuleName = Constant.UNCOVER_BACKGROUND;
            UpgradeReportPackage.ModuleName = Constant.UNCOVER_BACKGROUND;
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
                        output.AppendFormat("<li class=\"liChild\" style=\"background: none;margin-bottom: 0px;padding: 0px;margin: 0px;background-color: #e5e5e5;\"><a style=\"color:{4}\" href = \"#\" class=\"small\" data-countyid=\"{3}\" data-value=\"{0}\" tabindex=\"-1\"><input type = \"checkbox\" /> &nbsp; {1}&nbsp;({2}) </a></li>", county.DistrictCourtFees, (string.IsNullOrEmpty(county.County) ? "All Counties" : county.County), county.Id, county.Id, colorStyle);
                    }
                    output.AppendFormat("</ul></li>");
                }
                hdnCountyCriminalList.Value = output.ToString();
                hdnCountyCivilList.Value = output.ToString();
            }
        }

        List<AlacartReportDisplay> dispalyReport(int reportTypeId)
        {
            List<AlacartReportDisplay> alacartReports = new List<AlacartReportDisplay>();
            //string[] alacartReportList = { "eKnowID State Criminal Check", "eKnowID Criminal MultiState Check", "eKnowID Criminal MultiState Alias", 
            //                                 "OnSite County Check", "Federal Court", "eKnowID International", "Employment Verification", "Education Verification", 
            //                                 "IDentify", "Reference Verification", "eKnowID Drug Test", "Driving Record", "Credit" };

            //string[] alacartReportList = {"County Criminal Courthouse Search", "Federal Criminal Courthouse Search", "International Criminal Record Search",
            //                               "Employment Verification", "Education Verification", "Reference Verification",
            //                               "eKnowID Drug Test", "Driving Record", "County Civil Courthouse Search", "State Criminal Records", "Credit Report", "Global Security Watch List"};

            alacartReports = PlanHelper.GetAlacartReportList().Where(p => p.ReportTypeID == reportTypeId && p.IsActive)
                                        .Select(p => new AlacartReportDisplay 
                                        {
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

            //alacartReports.AddRange(reportls)
            //AlacartReportDisplay alacartReport;
            //foreach (string reportName in alacartReportList)
            //{
            //    foreach (Report report in reportLst)
            //    {
            //        if (report.Name == reportName && report.ReportTypeID == reportTypeId)
            //        {
            //            alacartReport = new AlacartReportDisplay();
            //            alacartReport.report = new Report();
            //            alacartReport.report.Name = report.Name;
            //            alacartReport.report.Description = report.Description;
            //            alacartReport.report.Price = report.Price;
            //            alacartReport.report.ReportId = report.ReportId;
            //            alacartReport.report.TurnaroundTime = report.TurnaroundTime;
            //            alacartReport.report.IsMultipleCheckEnabled = report.IsMultipleCheckEnabled;
            //            alacartReport.report.MaxVerificationCount = report.MaxVerificationCount;

            //            alacartReports.Add(alacartReport);
            //            break;
            //        }
            //    }
            //}

            return alacartReports;
        }

        protected void alacartReportList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                AlacartReportDisplay alacartReportDisplay = e.Item.DataItem as AlacartReportDisplay;
                UserControl control = e.Item.FindControl("AlacartReport") as UserControl;
                ManipulateReportDisplay(alacartReportDisplay.report, control);
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
        public static int SetSelectedAlacartReportList(string alacartReportList)
        {
            int flag = 0;
            if (!string.IsNullOrEmpty(alacartReportList))
            {
                SessionWrapper.AlacartReportList = new List<int>();
                int reportID;
                string[] reportIdList = alacartReportList.Split(',');
                foreach (string reportId in reportIdList)
                {
                    reportID = int.Parse(reportId);
                    SessionWrapper.AlacartReportList.Add(reportID);

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
                flag = 1;
            }
            else
            {
                SessionWrapper.AlacartReportList = new List<int>();
            }
            SessionWrapper.ModuleName = Constant.UNCOVER_BACKGROUND;
            return flag;
        }

        //[WebMethod]
        //public static void SetAdditionalInfoRequire()
        //{           
        //    SessionWrapper.RequiredInformation = new RequiredInformation();
        //    SessionWrapper.RequiredInformation.isEducationDetailsRequired = SessionWrapper.AlacartReportList.Contains(Constant.EDUCATION_REPORT_ID) ? true : false;
        //    SessionWrapper.RequiredInformation.isEmploymentDetailsRequired = SessionWrapper.AlacartReportList.Contains(Constant.EMPLOYEE_REPORT_ID) ? true : false;
        //    SessionWrapper.RequiredInformation.isReferenceInformationRequired = SessionWrapper.AlacartReportList.Contains(Constant.REFERENCE_REPORT_ID) ? true : false;
        //    SessionWrapper.RequiredInformation.isLicenseInformationRequired = SessionWrapper.AlacartReportList.Contains(Constant.LICENSE_REPORT_ID) ? true : false;
        //    SessionWrapper.RequiredInformation.isDrugVerificationRequired = SessionWrapper.AlacartReportList.Contains(Constant.DRUG_REPORT_ID) ? true : false;

        //}

        protected void btnChooseReport_Click(object sender, EventArgs e)
        {
            planOrderSummary.showPlanSummary();
        }

    }
    public class AlacartReportDisplay
    {
        public Report report { get; set; }
    }
}