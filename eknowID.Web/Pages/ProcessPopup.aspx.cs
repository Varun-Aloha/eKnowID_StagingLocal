using System;
using System.Web.UI;
using Brickred.SocialAuth.NET.Core.BusinessObjects;
using eknowID.AppCode;

namespace eknowID.Pages
{
    public partial class ProcessPopup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["provider"] != null)
                {
                    PROVIDER_TYPE providerType = (PROVIDER_TYPE)Enum.Parse(typeof(PROVIDER_TYPE), Request.QueryString["provider"].ToUpper());
                    SocialAuthUser.GetCurrentUser().Login(providerType, "Pages/ProcessPopup.aspx", errorRedirectURL: "Pages/ProcessPopup.aspx");
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "closeWindow", "closeWindow();", true);
                }
                else if (Request.QueryString["error_message"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "closeWindow", "showErrorMsg('An error has occured');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "closeWindow", "closeWindow();", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "closeWindow", "closeWindow();", true);
            }

        }
    }
}