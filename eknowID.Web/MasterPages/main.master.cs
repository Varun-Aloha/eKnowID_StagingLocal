using System;
using System.Web;
using System.Web.UI;
using eknowID.AppCode;
using EknowIDLib;

namespace eknowID
{
    public partial class main : System.Web.UI.MasterPage
    {
        public int? userType;
        public bool loadLoginPopups = true;
        public int? isAdminUser;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (this.Page is IAuthenticationRequired)
            {
                if (SessionWrapper.LoggedUser == null)
                    Response.Redirect("~/Pages/index.aspx");
            }
            if (SessionWrapper.LoggedUser != null) {                
                //set Admin
                userType = SessionWrapper.LoggedUser.UserType;

                if (userType == null) {
                    userType = (int)UserTypeEnum.NORMAL_USER;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            if (SessionWrapper.LoggedUser != null)
            {
                loadLoginPopups = false;
                pnlSignIn.Visible = false;
                pnlSignedIn.Visible = true;
                string userName = SessionWrapper.LoggedUser.FirstName.ToString();
                lblUserName.Text = userName.Length >= 10 ? userName.Substring(0, 10) : userName.Substring(0, userName.Length);
                hdnSessionFlag.Value = "true";

                //Set Content management page access
                isAdminUser = SessionWrapper.LoggedUser.UserType;
            }
            else
            {
                hdnSessionFlag.Value = "false";
                pnlSignIn.Visible = true;
                pnlSignedIn.Visible = false;
            }

            //if (!(Request.RawUrl.Contains("UserProfile")) && (!(Request.RawUrl.Contains("OrderDetail"))))
            //{
            //SessionWrapper.LinkedinData = null;
            //SessionWrapper.ResumeParserData = null;
            //}
        }

        protected void lnkBtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            SessionWrapper.LoggedUser = null;

            string loggedOutPageUrl;

            if (this.Page is IAuthenticationRequired)
            {
                loggedOutPageUrl = "../Pages/index.aspx";
            }
            else
            {
                loggedOutPageUrl = Request.RawUrl;
                if (Request.RawUrl.Contains("UpgradeReportPackage"))
                {
                    loggedOutPageUrl = "../Pages/index.aspx";
                }
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory('" + loggedOutPageUrl + "');", true);
        }

        protected void GetSessionStatus(object sender, EventArgs e)
        {
            if (SessionWrapper.LoggedUser != null)
            {
                loadLoginPopups = false;
                pnlSignIn.Visible = false;
                pnlSignedIn.Visible = true;
                string userName = SessionWrapper.LoggedUser.FirstName.ToString();
                lblUserName.Text = userName.Length >= 10 ? userName.Substring(0, 10) : userName.Substring(0, userName.Length);
                hdnSessionFlag.Value = "true";                
            }
            else
            {
                hdnSessionFlag.Value = "false";
                pnlSignIn.Visible = true;
                pnlSignedIn.Visible = false;
            }
        }
    }
}