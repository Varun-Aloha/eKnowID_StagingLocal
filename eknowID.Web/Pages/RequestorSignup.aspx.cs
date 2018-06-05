using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using eknowID.WebApi.Models;
using System;
using System.Web.Services;

namespace eknowID.Pages
{
    public partial class RequestorSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool MakeSignup(RequesterViewModel requesterViewModel)
        {
            var response = new PackageService().SaveRequesterDetails(requesterViewModel);

            if (response == null) return false;

            SessionWrapper.LoggedUser = new EknowIDModel.User()
            {
                FirstName = response.FirstName,
                LastName = response.LastName,
                UserId = response.UserId,
                Email = response.Email,
                IsAdmin = true,
                CompanyId = response.CompanyId
            };

            return true;
        }

        [WebMethod]
        public static bool AddNewUsersByMasterAdmin(RequesterViewModel requesterViewModel)
        {
            requesterViewModel.Requester.CompanyId = SessionWrapper.LoggedUser.CompanyId;
            var response = new PackageService().AddNewUsersByMasterAdmin(SessionWrapper.LoggedUser.UserId, requesterViewModel);

            return response != null ? true : false;
        }
    }
}