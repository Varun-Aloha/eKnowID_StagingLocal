using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using EknowIDModel;
using EknowIDData.Helper;
using eknowID.AppCode;
using System.Text;
using System.IO;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class CMS_HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionWrapper.LoggedUser == null || SessionWrapper.LoggedUser.Email != Constant.CONST_CMS_ADMIN_USERID)
                    Response.Redirect("~/Pages/index.aspx");

                if (SessionWrapper.CMSHomePage != null)
                {
                    SetCMSData();
                }

            }
        }

        //Set Home Page Content
        [WebMethod]
        public static bool SetPreviewHomePageContent(string TestimonialsContent, string TestimonialsSignName, string TestimonialsSignComapnyName, string BlogHeader, string BlogContent, string YouTubeSRC, string TestimonialsImage, bool previewFlag)
        {
            bool flag = true;
            try
            {
                TestimonialsContent = TestimonialsContent.Replace("¤", "'");
                TestimonialsSignName = TestimonialsSignName.Replace("¤", "'");
                TestimonialsSignComapnyName = TestimonialsSignComapnyName.Replace("¤", "'");
                BlogHeader = BlogHeader.Replace("¤", "'");
                BlogContent = BlogContent.Replace("¤", "'");
                
                SessionWrapper.CMSHomePage = new CMSHomePage();
                SessionWrapper.CMSHomePage.PreviewFlag =previewFlag==true?true:false;
                SessionWrapper.CMSHomePage.testimonials_content = TestimonialsContent;
                SessionWrapper.CMSHomePage.testimonials_Sign_Name = TestimonialsSignName;
                SessionWrapper.CMSHomePage.testimonials_Sign_CompanyName = TestimonialsSignComapnyName;
                SessionWrapper.CMSHomePage.Blog_Header = BlogHeader;
                SessionWrapper.CMSHomePage.Blog_Content = BlogContent;
                SessionWrapper.CMSHomePage.YoutubeSrc = YouTubeSRC;
                SessionWrapper.CMSHomePage.testimonials_imageName = TestimonialsImage;

                if(previewFlag==false)
                CMSHomePageHelper.SetCMSHomePageContent(SessionWrapper.CMSHomePage, previewFlag);
            }
            catch { flag = false; }
            return flag;
        }

        //Upload Testimonials Image
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {                

                if (imgUpload.HasFile)
                {
                    if (File.Exists(MapPath("~/Images/" + imgUpload.FileName)))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type=text/javascript>");
                        sb.Append(" OpenDialog('File Exist Already!!!', function () {});");
                        sb.Append("</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
                    }
                    else
                    {
                        imgUpload.SaveAs(MapPath("~/Images/" + imgUpload.FileName));

                        hdnTestimonialsImg.Value = imgUpload.FileName;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type=text/javascript>");
                        sb.Append(" OpenDialog('File Uploaded Successfully!!!', function () {});");
                        sb.Append("</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
                    }
                }
            }
            catch { }
        }

        //Clear CMS Session
        [WebMethod]
        public static void ClearPreviewHomePageContent()
        {
            SessionWrapper.CMSHomePage = new CMSHomePage();
        }

        private void SetCMSData()
        {
            txtTestimonialsContent.Text = SessionWrapper.CMSHomePage.testimonials_content;
            txtTestimonialsSignatureName.Text = SessionWrapper.CMSHomePage.testimonials_Sign_Name;
            txtTestimonialsSignCompanyName.Text = SessionWrapper.CMSHomePage.testimonials_Sign_CompanyName;
            txtBlogHeader.Text = SessionWrapper.CMSHomePage.Blog_Header;
            txtBlogContent.Text = SessionWrapper.CMSHomePage.Blog_Content;
            txtYouTubeSRC.Text = SessionWrapper.CMSHomePage.YoutubeSrc;
        }
    }
}