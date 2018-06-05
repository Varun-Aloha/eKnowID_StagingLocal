using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using System;
using System.Web.UI;

namespace eknowID.Pages
{
    public partial class RequesterCompany : System.Web.UI.Page
    {
        PackageService packageService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionWrapper.LoggedUser != null)
            {
                Response.Redirect("../Pages/Index.aspx");
            }

            packageService = new PackageService();
        }

        protected void btnRequesterCompany_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var company = new Company()
                {
                    Name = txtCompanyName.Text,
                    JobTitle = txtJobTitle.Text,
                    CompanyPhone = txtCompanyPhone.Text,
                    CompanyTaxId = txtCompanyTaxId.Text,
                    Description = txtCompnyDescription.Text ?? string.Empty
                };

                if (SessionWrapper.RequesterSignupInformation != null)
                {
                    var requesterViewModel = new RequesterViewModel()
                    {
                        Requester = SessionWrapper.RequesterSignupInformation,
                        Company = company
                    };

                    var response = packageService.SaveRequesterDetails(requesterViewModel);

                    if (response != null)
                    {
                        var user = new EknowIDModel.User()
                        {
                            FirstName = response.FirstName,
                            LastName = response.LastName,
                            UserId = response.UserId,
                            Email = response.Email

                        };

                        SessionWrapper.LoggedUser = user;

                        //check user to redirect package screen or index page using javascript function

                        if (SessionWrapper.IsPackageSelected)
                        {
                            Response.Redirect("../Pages/ApplicantPackages.aspx");
                        }

                        Response.Redirect("../Pages/Index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../Pages/RequesterAccount.aspx");
                }
            }
        }
    }
}