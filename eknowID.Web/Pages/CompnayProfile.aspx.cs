using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using System;
using System.Web.Services;

namespace eknowID.Pages
{
    public partial class CompnayProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static bool CreateCompnayProfile(Company company)
        {
            PackageService packageService = new PackageService();

            company.CreatedOn = DateTime.Now; // inserted current datetime value.

            var companyId = packageService.CreateCompnayProfile(SessionWrapper.LoggedUser.UserId, company);

            if (companyId != 0)
            {
                SessionWrapper.LoggedUser.CompanyId = companyId;
                return true;
            }
            return false;
        }
    }
}