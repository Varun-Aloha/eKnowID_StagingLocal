using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using System;

namespace eknowID.Pages
{
    public partial class Alacarte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionWrapper.SelectedPlanType == null)
            {
                Response.Redirect("../Pages/PackageType.aspx");
                return;
            }

            AlacarteRepeater1.DataSource = new PackageService().GetAlacartReport();
            AlacarteRepeater1.DataBind();

            var selectedPlanType = new PackageService().GetSelectedPlanType(SessionWrapper.SelectedPlanType);

            planName.Text = selectedPlanType.Name;
            planPrice.Text = selectedPlanType.Rate.ToString();

            //packageType.DataSource = selectedPlanType.Description;
            //packageType.DataBind();
        }

        protected void AlacarteContinue_Click(object sender, EventArgs e)
        {
            Session["alacarteDetail"] = AlacarteList.Value;
            Session["alacarteTotal"] = AlacarteTotal.Value;

            if (SessionWrapper.LoggedUser != null)
            {
                Response.Redirect("../Pages/RequesterPayment.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ModalPopup", "openLoginModal()", true);
            }
        }
    }
}