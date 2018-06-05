using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using System;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class RequesterCandidate : System.Web.UI.Page, IAuthenticationRequired
    {
        PackageService packageService;

        public RequesterCandidate()
        {
            packageService = new PackageService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionWrapper.PaymentOrderId == 0)
            {
                Response.Redirect("../Pages/Index.aspx");
            }

            //check wether compnay profile is exist or not            
            if (!Page.IsPostBack)
            {
                var isPresent = packageService.IsCompanyProfilePresent(SessionWrapper.LoggedUser.UserId);

                if (!isPresent)
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "openCompnayProfileModal", "openCompnayProfileModal();", true);

                BindGridView();
            }
        }

        protected void btnRequesterCandidate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            if (SessionWrapper.PaymentOrderId == 0)
            {
                Response.Redirect("../Pages/Index.aspx");
                return;
            }

            var candidate = new Candidate()
            {
                FirstName = txtCandiFirstName.Text,
                LastName = txtCandiLastName.Text,
                Email = txtCandiEmail.Text,
                Description = drpCandidate.SelectedItem.Text,
                OrderId = SessionWrapper.PaymentOrderId,
                UserId = SessionWrapper.LoggedUser.UserId,
                CreatedOn = DateTime.Now
            };

            SaveCandidateDetail(candidate);
        }

        protected void lnkbtnRunChk_Click(object sender, EventArgs e)
        {
            if (SessionWrapper.PaymentOrderId == 0)
            {
                Response.Redirect("../Pages/Index.aspx");
                return;
            }

            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            var firstName = gridExistsApplicant.Rows[row.RowIndex].FindControl("hdnFirstName") as HiddenField;
            var lastName = gridExistsApplicant.Rows[row.RowIndex].FindControl("hdnLastName") as HiddenField;
            var email = gridExistsApplicant.Rows[row.RowIndex].FindControl("hdnEmail") as HiddenField;
            var description = gridExistsApplicant.Rows[row.RowIndex].FindControl("hdnDescription") as HiddenField;

            var candidate = new Candidate()
            {
                FirstName = firstName.Value,
                LastName = lastName.Value,
                Email = email.Value,
                Description = description.Value,
                OrderId = SessionWrapper.PaymentOrderId,
                UserId = SessionWrapper.LoggedUser.UserId
            };

            SaveCandidateDetail(candidate);
        }

        protected void gridExistsApplicant_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridExistsApplicant.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        #region Private Section
        private void SaveCandidateDetail(Candidate candidate)
        {
            var response = new PackageService().SaveCandidateDetail(candidate);

            if (response)
            {
                //remove all session value

                SessionWrapper.SelectedPlanType = 0;
                SessionWrapper.PaymentOrderId = 0;

                //redirect to dashboard screen
                Response.Redirect("../Pages/AdminDashboard.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "showErrorDialog", "showErrorDialog('Enable to save candidate information we contact you as soon as possible!')", true);
            }
        }

        //Bind gridview
        private void BindGridView()
        {
            gridExistsApplicant.DataSource = new PackageService().GetExistsApplicanDetail(SessionWrapper.LoggedUser.UserId);
            gridExistsApplicant.DataBind();
        }
        #endregion

        [WebMethod]
        public static bool IsPresentCompnay()
        {
            var packageService = new PackageService();
            return packageService.IsCompanyProfilePresent(SessionWrapper.LoggedUser.UserId);
        }

        [WebMethod]
        public static bool IsCandidateEmailPresent(string email)
        {
            var packageService = new PackageService();
            return packageService.IsCandidateEmailPresent(SessionWrapper.LoggedUser.UserId, email);
        }
    }
}