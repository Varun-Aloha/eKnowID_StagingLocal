using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Results;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class ApplicantAlacarte : System.Web.UI.Page
    {
        PackageService packageService;

        public ApplicantAlacarte()
        {
            packageService = new PackageService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SessionWrapper.SelectedPlanType == 0)
                    Response.Redirect("../Pages/ApplicantPackages.aspx");

                reptAlacarteCriminalReport.DataSource = dispalyReport(Constant.CRIMINAL_REPORT_TYPE);
                reptAlacarteCriminalReport.DataBind();

                reptAlacarteVerificationReport.DataSource = dispalyReport(Constant.VERIFICATION_REPORT_TYPE);
                reptAlacarteVerificationReport.DataBind();

                reptAlacarteMiscellaneousReport.DataSource = dispalyReport(Constant.MISCELLANEOUS_REPORT_TYPE);
                reptAlacarteMiscellaneousReport.DataBind();

                var selectedPlan = packageService.GetSelectedPlanType(SessionWrapper.SelectedPlanType);
                litePlanName.Text = selectedPlan.Name;
                lblPrice.Text = selectedPlan.Rate.Value.ToString("00.00");
                hdnPlanPrice.Value = selectedPlan.Rate.Value.ToString("00.00");

                var rprts = new List<string>();

                foreach (var plnRprt in selectedPlan.PlanReports)
                {
                    rprts.Add(plnRprt.Report.Name);
                }

                rptrPlnRprts.DataSource = rprts;
                rptrPlnRprts.DataBind();
            }
            GetStateCriminalAccessFeesList();
            GetCountyCriminalAccessFeesList();
            GetFederalCriminalAccessFeesList();
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
                    output.AppendFormat("<li style =\"background: none;margin-bottom: 0px;padding: 0px;margin: 0px;background-color: #e5e5e5;\">{0}</li>" +
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
                                 }).GroupBy(p=>p.StateId);

                //ddlStates.DataTextField = "Name";
                //ddlStates.DataValueField = "Fee";
                //ddlStates.DataSource = stateList;
                //ddlStates.DataBind();

                //ddlStates.Items.Insert(0, new ListItem("Select State", "0"));
                //ddlStates.SelectedIndex = 0;

                StringBuilder output = new StringBuilder();

                foreach (var stateCounties in countyList) {
                    var state = stateCounties.FirstOrDefault().Name;
                    output.AppendFormat("<li class=\"liParent\" style =\"background: none;margin-bottom: 0px;padding: 0px;margin: 0px;background-color: #e5e5e5;\">{0}" +
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

        private void GetStateCriminalAccessFeesList() {
            if (ddlStates.Items.Count == 0) {
                IRepository<EknowIDModel.StateCriminalCourtFee> state_criminal = new Repository<EknowIDModel.StateCriminalCourtFee>();
                IList<EknowIDModel.StateCriminalCourtFee> stateList = state_criminal.SelectAll().Where(p=> !p.Availability.Trim().ToLower().Equals("not available")).ToList();

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

        protected void btnOrderContinue_Click(object sender, EventArgs e)
        {
            var IsCreditReportAuditingChargesPaid = false;
            bool.TryParse(hdnIsCreditReportAuditingChargesPaid.Value, out IsCreditReportAuditingChargesPaid);

            SessionWrapper.AlacartReportList = new List<int>();
            SessionWrapper.AlacartReportListWithQty = new Dictionary<int, int>();
            SessionWrapper.SelectedStates = hdnStateCriminalSelectList.Value;
            SessionWrapper.SelectedCounties = hdnCountyCriminalSelectList.Value;
            SessionWrapper.SelectedCivilCounties = hdnCountyCivilSelectList.Value;
            SessionWrapper.SelectedDistricts = hdnFederalCriminalSelectList.Value;
            SessionWrapper.IsCreditReportAuditingChargesPaid = IsCreditReportAuditingChargesPaid;

            string[] reportIdList = hdnReport.Value.Split(',');
            string[] reportQtyList = hdnReportQty.Value.Split(',');

            int reportID;
            int reportQty;
            if (reportIdList[0] != "")
            {
                int i = 0;
                foreach (string reportId in reportIdList)
                {
                    reportID = Convert.ToInt32(reportId);
                    reportQty = Convert.ToInt32(reportQtyList[i]);
                    SessionWrapper.AlacartReportList.Add(reportID);
                    SessionWrapper.AlacartReportListWithQty.Add(reportID, reportQty);
                    i++;
                }
            }

            SessionWrapper.TotalReportPrice = hdnTotalPrice.Value;

            if (SessionWrapper.LoggedUser == null)
            {
                hdnContinueBtnClick.Value = "True";

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "openLoginModal", "openLoginModal()", true);
            }
            else
            {
                Response.Redirect("../Pages/RequesterPayment.aspx");
            }
        }

        List<Report> dispalyReport(int reportTypeId)
        {
            var alacartReports = new List<Report>();

            //string[] alacartReportList = { "County Criminal Courthouse Search", "Federal Criminal Courthouse Search", "International Criminal Record Search", 
            //                               "Employment Verification", "Education Verification", "Reference Verification", 
            //                               "eKnowID Drug Test", "Driving Record", "County Civil Courthouse Search", "State Criminal Records", "Credit Report", "Global Security Watch List"};

            alacartReports = packageService.GetAlacartReport().Where(p => p.ReportTypeID == reportTypeId && p.IsActive).ToList();

            //foreach (string reportName in alacartReportList)
            //{
            //    foreach (Report report in reportLst)
            //    {
            //        if (report.Name == reportName && report.ReportTypeID == reportTypeId)
            //        {
            //            alacartReports.Add(report);
            //            break;
            //        }
            //    }
            //}
            return alacartReports;
        }

        [WebMethod]
        public static bool CheckIfUserIsLoggedIn() {
            if (SessionWrapper.LoggedUser == null) {
                return false;
                //var page = HttpContext.Current.CurrentHandler as Page;
                //page.ClientScript.RegisterStartupScript(page.GetType(), "openLoginModal", "openLoginModal()", true);
            } else {
                return true;
            }
            //else {

            //    var isPresent = packageService.IsCompanyProfilePresent(SessionWrapper.LoggedUser.UserId);

            //    if (!isPresent) {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "openCompnayProfileModal", "openCompnayProfileModal();", true);
            //    }
            //}
        }
        [WebMethod]
        public static bool CheckForUserCompanyDetails() {
            PackageService packageService = new PackageService();
            return packageService.IsCompanyProfilePresent(SessionWrapper.LoggedUser.UserId);
        }

        [WebMethod]
        public static Dictionary<string,bool?> VerifyCreditReportCredentialingAuditStatusForCompany() {
            Dictionary<string, bool?> CredentialingAuditStatusForCompany = new Dictionary<string, bool?>();
            PackageService packageService = new PackageService();
            var user = packageService.GetUsersLists(3, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId).FirstOrDefault();
            
            CredentialingAuditStatusForCompany.Add("IsEligibleForCreditReportAuditing", user.Company.IsEligibleForCreditReportScreening);
            CredentialingAuditStatusForCompany.Add("IsCreditReportAuditingChargesPaid", user.Company.IsCreditReportAuditingChargesPaid);

            return CredentialingAuditStatusForCompany;
        }
    }
}