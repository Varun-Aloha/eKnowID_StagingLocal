using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using eknowID.AppCode;
using System.Web.Services;

namespace eknowID.Pages
{
    public partial class SearchByProf_ChoosePlan : BaseAbstractClass
    {
        public List<PagePlanDisplay> plans;

        public bool isReferenceInfo;
        public bool isEmploymentDetails;
        public bool isLicenseDetails;
        public bool isEducationDetails;
        public bool isDrugVerificationReq;
        public bool isUserlogged;


        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            if (SessionWrapper.LoggedUser != null)
            {
                isUserlogged = true;
                hdnUserLoggedIn.Value = "True";
            }
            else
            {
                isUserlogged = false;
                hdnUserLoggedIn.Value = "False";
            }

            //if professionis not selected redirect to step 1 to select profession
            if (SessionWrapper.OrderDetail == null || SessionWrapper.OrderDetail.ProfessionId == 0)
            {
                Response.Redirect("SearchByProf_SelectProf.aspx");
            }

            if (!IsPostBack)
            {
                plansList.DataSource = DisplayPlans();
                plansList.DataBind();             
               // SessionWrapper.CheckPageRefresh = Server.UrlDecode(System.DateTime.Now.ToString());             
                string browserVersion = Request.Browser.Type;
                if (browserVersion == "IE8")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tab1", "page1height();", true);
                }
            }         
        }
        public override void GetDetails()
        {
            if (SessionWrapper.RequiredInformation != null)
            {
                isReferenceInfo = SessionWrapper.RequiredInformation.isReferenceInformationRequired;
                isEmploymentDetails = SessionWrapper.RequiredInformation.isEmploymentDetailsRequired;
                isLicenseDetails = SessionWrapper.RequiredInformation.isLicenseInformationRequired;
                isEducationDetails = SessionWrapper.RequiredInformation.isEducationDetailsRequired;
                isDrugVerificationReq = SessionWrapper.RequiredInformation.isDrugVerificationRequired;
                hdnDrugVerification.Value = isDrugVerificationReq.ToString();

                if (isReferenceInfo || isEmploymentDetails || isLicenseDetails || isEducationDetails)
                {
                    hdnDetailsPopups.Value = "True";
                }
                else
                {
                    hdnDetailsPopups.Value = "False";
                }
            }
        }

        List<PagePlanDisplay> DisplayPlans()
        {
            List<PagePlanDisplay> plans = new List<PagePlanDisplay>();

            if (SessionWrapper.OrderDetail != null && SessionWrapper.OrderDetail.ProfessionId != 0)
            {
                int professionID = SessionWrapper.OrderDetail.ProfessionId;

                ISpecification<ProfessionPlan> planSpe = new Specification<ProfessionPlan>(p => p.ProfessionId == professionID);
                IRepository<ProfessionPlan> planRep = new Repository<ProfessionPlan>();
                IList<ProfessionPlan> professionPlans = planRep.SelectAll(planSpe);

                int row = 0;
                int col = 0;

                PagePlanDisplay currentPlan = new PagePlanDisplay();
                foreach (ProfessionPlan professionPlan in professionPlans)
                {
                    planRep.LoadRelatedProperties(professionPlan, new string[] { "Plan" });

                    switch (col % 3)
                    {
                        case 0:
                            currentPlan.plan1 = professionPlan.Plan;
                            break;
                        case 1:
                            currentPlan.plan2 = professionPlan.Plan;
                            break;
                        case 2:
                            currentPlan.plan3 = professionPlan.Plan;
                            break;
                    }
                    col++;

                    if (col > 2 || ((row * 3) + col) == professionPlans.Count)
                    {
                        plans.Add(currentPlan);
                        currentPlan = new PagePlanDisplay();
                    }


                    if (col > 2)
                    {
                        row++;
                        col = 0;
                    }

                }
            }

            //get optional reports for profession
            List<PageReportData> reports = new List<PageReportData>();
            if (SessionWrapper.OrderDetail != null && SessionWrapper.OrderDetail.ProfessionId != 0)
            {
                int professionID = SessionWrapper.OrderDetail.ProfessionId;

                ISpecification<ProfessionReport> proRepSpec = new Specification<ProfessionReport>(p => p.ProfessionId == professionID);
                IRepository<ProfessionReport> proRep = new Repository<ProfessionReport>();
                IList<ProfessionReport> professionReports = proRep.SelectAll(proRepSpec);
                foreach (ProfessionReport professionReport in professionReports)
                {
                    proRep.LoadRelatedProperties(professionReport, new string[] { "Report" });
                    reports.Add(new PageReportData(professionReport.Report.Name, professionReport.Report.Description, professionReport.Report.ReportId, professionReport.Report.Price));
                }
                foreach (PagePlanDisplay pagePlanDisplay in plans)
                {
                    pagePlanDisplay.optionalReports = reports;
                }
            }

            return plans;
        }

        protected void plansList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PagePlanDisplay planDisplay = e.Item.DataItem as PagePlanDisplay;

                UserControl control1 = e.Item.FindControl("PlanDisplay1") as UserControl;
                ManipulatePlanDisplay(planDisplay.plan1, e, planDisplay, control1, planDisplay.optionalReports);

                UserControl control2 = e.Item.FindControl("PlanDisplay2") as UserControl;
                ManipulatePlanDisplay(planDisplay.plan2, e, planDisplay, control2, planDisplay.optionalReports);

                UserControl control3 = e.Item.FindControl("PlanDisplay3") as UserControl;
                ManipulatePlanDisplay(planDisplay.plan3, e, planDisplay, control3, planDisplay.optionalReports);
            }
        }

        private static void ManipulatePlanDisplay(Plan plan, RepeaterItemEventArgs e, PagePlanDisplay planDisplay, UserControl control, List<PageReportData> optionalReports)
        {

            if (plan != null)
            {
                eknowID.Controls.PlanDisplay uPlanCon = control as eknowID.Controls.PlanDisplay;
                if (uPlanCon != null)
                {
                    uPlanCon.plan = plan;
                }
            }
            else
            {
                eknowID.Controls.PlanDisplay uPlanCon = control as eknowID.Controls.PlanDisplay;
                if (uPlanCon != null)
                {
                    uPlanCon.Visible = false;

                }
            }
        }

    }

    public class PagePlanDisplay
    {
        public Plan plan1 { get; set; }
        public Plan plan2 { get; set; }
        public Plan plan3 { get; set; }
        public List<PageReportData> optionalReports { get; set; }
    }

}