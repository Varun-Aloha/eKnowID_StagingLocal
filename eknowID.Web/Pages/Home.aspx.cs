using System;
using System.Web.UI;
using EknowIDModel;
using EknowIDData.Helper;
using eknowID.AppCode;
using System.Net;
using System.IO;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class Home : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {               
                Page.Title = "eKnowID | Home | Online Background Checks, Criminal Records Search, Employment Verification, Tenant Check and more @ eKnowID";
                Page.MetaKeywords = "eKnowID, background check, background checks, employment verification, tenant check, self check, criminal records, where to get background check, online background check, background check online, record check";
                Page.MetaDescription = "Background checks that you can now easily afford. eKnowID makes background checks easy on the pocket and as simple as 1-2-3.";

                //Set Content of testimonials,Blog
                CMSHomePage cmsHomePage = CMSHomePageHelper.GetCMSHomePageContent(false);
                if (SessionWrapper.LoggedUser != null)
                {
                    if ((SessionWrapper.LoggedUser.Email == Constant.CONST_CMS_ADMIN_USERID) && (SessionWrapper.CMSHomePage != null && SessionWrapper.CMSHomePage.PreviewFlag == true))
                    {                     
                        cmsHomePage.Blog_Header =!string.IsNullOrEmpty(SessionWrapper.CMSHomePage.Blog_Header) ? SessionWrapper.CMSHomePage.Blog_Header : cmsHomePage.Blog_Header;
                        cmsHomePage.Blog_Content = !string.IsNullOrEmpty(SessionWrapper.CMSHomePage.Blog_Content)? SessionWrapper.CMSHomePage.Blog_Content : cmsHomePage.Blog_Content;
                        cmsHomePage.testimonials_content =!string.IsNullOrEmpty( SessionWrapper.CMSHomePage.testimonials_content ) ? SessionWrapper.CMSHomePage.testimonials_content : cmsHomePage.testimonials_content;
                        cmsHomePage.testimonials_Sign_Name =!string.IsNullOrEmpty( SessionWrapper.CMSHomePage.testimonials_Sign_Name ) ? SessionWrapper.CMSHomePage.testimonials_Sign_Name : cmsHomePage.testimonials_Sign_Name;
                        cmsHomePage.testimonials_Sign_CompanyName = !string.IsNullOrEmpty(SessionWrapper.CMSHomePage.testimonials_Sign_CompanyName) ? SessionWrapper.CMSHomePage.testimonials_Sign_CompanyName : cmsHomePage.testimonials_Sign_CompanyName;
                        cmsHomePage.testimonials_imageName =!string.IsNullOrEmpty( SessionWrapper.CMSHomePage.testimonials_imageName) ? SessionWrapper.CMSHomePage.testimonials_imageName : cmsHomePage.testimonials_imageName;
                        cmsHomePage.YoutubeSrc = !string.IsNullOrEmpty(SessionWrapper.CMSHomePage.YoutubeSrc) ? SessionWrapper.CMSHomePage.YoutubeSrc : cmsHomePage.YoutubeSrc;
                    }
                }

                setTestimonialsBlogContent(cmsHomePage);
               
            }
            catch { }
        }

        public string get_web_content(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string output = reader.ReadToEnd();
            response.Close();
            return output;

        }
        protected void imgBtnRunId_Click(object sender, ImageClickEventArgs e)
        {
            SessionWrapper.OrderDetail = null;
            SessionWrapper.OrderDetail = new OrderDetails();
            SessionWrapper.OrderDetail.ProfessionId = Constant.ID_THEFT_PROFID;
            SessionWrapper.ModuleName = Constant.IDENTITY_THEFT;

            Response.Redirect("../Pages/SelectProf_PackageSelection.aspx");
        }


        private void setTestimonialsBlogContent(CMSHomePage cmsHomePage)
        {
            divTestimonialsContent.InnerHtml = cmsHomePage.testimonials_content;
            divTestimonialsSignature.InnerHtml = cmsHomePage.testimonials_Sign_Name + "<br/>" + cmsHomePage.testimonials_Sign_CompanyName;
            imgTestimonialsImage.Src = "~/Images/" + cmsHomePage.testimonials_imageName;
            lblBlogHeader.Text = cmsHomePage.Blog_Header;
            divBlogContent.InnerHtml = cmsHomePage.Blog_Content + " " + "<a class='SearchByRefUC_heading' style='text-decoration: none;font-weight: bold; color: #4A80C0 !important;' href='http://eknowid.wordpress.com/' target='_blank'>Read More</a>";
            iframeYoutube.Attributes.Add("src", cmsHomePage.YoutubeSrc+"&wmode=transparent");
        }
    }
}