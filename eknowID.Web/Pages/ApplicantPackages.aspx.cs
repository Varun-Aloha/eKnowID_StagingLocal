using eknowID.AppCode;
using eknowID.Services;
using EknowIDLib;
using System;

namespace eknowID.Pages
{
    public partial class ApplicantPackages : System.Web.UI.Page
    {
        PackageService packageService;

        public ApplicantPackages() {
            packageService = new PackageService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var packageService = new PackageService();

                SessionWrapper.OrderType = packageService.GetApplicantOrderTypeId();

                var planType = packageService.GetPlanTypes();

                foreach (var item in planType)
                {
                    if (item.PlanName == Constant.BasicPlanType)
                    {
                        hdnBasicPlanId.Value = item.PlanId.ToString();
                        lblBasic.Text = item.PlanName;
                        lblBasicPrice.Text = item.Rate.Value.ToString("00.00");

                        rptrBasicReports.DataSource = item.ReportViewModal;
                        rptrBasicReports.DataBind();
                    }
                    else if (item.PlanName == Constant.StandardPlanType)
                    {
                        hdnStandardPlanId.Value = item.PlanId.ToString();
                        lblStandred.Text = item.PlanName;
                        lblStandredPrice.Text = item.Rate.Value.ToString("00.00");

                        rptrStandardReports.DataSource = item.ReportViewModal;
                        rptrStandardReports.DataBind();
                    }
                    else if (item.PlanName == Constant.PremiumPlanType)
                    {
                        hdnPremiumPlanId.Value = item.PlanId.ToString();
                        lblTophire.Text = item.PlanName;
                        lblTophirePrice.Text = item.Rate.Value.ToString("00.00");

                        rptrTophireReports.DataSource = item.ReportViewModal;
                        rptrTophireReports.DataBind();
                    }
                }
            }
        }

        protected void btnPkgBasic_Click(object sender, EventArgs e)
        {
            SessionWrapper.SelectedPlanType = Convert.ToInt32(hdnBasicPlanId.Value);
            Response.Redirect("../Pages/ApplicantAlacarte.aspx");
        }

        protected void btnPkgStandard_Click(object sender, EventArgs e)
        {
            SessionWrapper.SelectedPlanType = Convert.ToInt32(hdnStandardPlanId.Value);
            Response.Redirect("../Pages/ApplicantAlacarte.aspx");
        }

        protected void btnPkgPremium_Click(object sender, EventArgs e)
        {
            SessionWrapper.SelectedPlanType = Convert.ToInt32(hdnPremiumPlanId.Value);
            Response.Redirect("../Pages/ApplicantAlacarte.aspx");
        }        
    }
}