using System;
using eknowID.AppCode;
using EknowIDModel;
using EknowIDData.Helper;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class YouTubeVideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CMSHomePage cmsHomePage = CMSHomePageHelper.GetCMSHomePageContent(false);
                if (SessionWrapper.LoggedUser != null)
                {
                    if ((SessionWrapper.LoggedUser.Email == Constant.CONST_CMS_ADMIN_USERID) && (SessionWrapper.CMSHomePage != null && SessionWrapper.CMSHomePage.PreviewFlag == true))
                        cmsHomePage.YoutubeSrc = SessionWrapper.CMSHomePage.YoutubeSrc != null ? SessionWrapper.CMSHomePage.YoutubeSrc : cmsHomePage.YoutubeSrc;
                }

                iframeYoutube.Attributes.Add("src", cmsHomePage.YoutubeSrc + "&autoplay=1");
            }
            catch { }
        }
    }
}