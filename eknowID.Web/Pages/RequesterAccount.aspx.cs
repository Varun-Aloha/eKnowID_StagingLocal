using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class RequesterAccount : System.Web.UI.Page
    {
        PackageService packageService;

        protected void Page_Load(object sender, EventArgs e)
        {
            packageService = new PackageService();

            if (SessionWrapper.LoggedUser != null)
            {
                Response.Redirect("../Pages/Index.aspx");
            }
        }


        protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value.Length > 6 && e.Value.Length < 15)
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        protected void btnRequesterSignup_Click(object sender, EventArgs e)
        {            
            if (Page.IsValid)
            {
                var user = new User()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtRequesterEmail.Text,
                    Password = txtRequPassword.Text
                };

                SessionWrapper.RequesterSignupInformation = user;

                Response.Redirect("../Pages/RequesterCompany.aspx");
            }
        }
    }
}