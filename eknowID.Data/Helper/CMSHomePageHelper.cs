using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
   public class CMSHomePageHelper
    {
       /// <summary>
       /// Retreive Home Page CMS content
       /// </summary>
       /// <returns></returns>
       public static CMSHomePage GetCMSHomePageContent(bool previewFlag)
       {           
           ISpecification<CMSHomePage> CMSHomePageSpc = new Specification<CMSHomePage>(cms => cms.PreviewFlag == previewFlag);
           IRepository<CMSHomePage> CMSHomePageRepository = new Repository<CMSHomePage>("PreviewFlag");
           return CMSHomePageRepository.SelectAll(CMSHomePageSpc).LastOrDefault(); 
       }


       /// <summary>
       /// Set Preview Home Page CMS content
       /// </summary>
       /// <returns></returns>
       public static void SetCMSHomePageContent(CMSHomePage CMSHomePageData, bool previewFlag)
       {
           ISpecification<CMSHomePage> CMSHomePageSpc = new Specification<CMSHomePage>(cms => cms.PreviewFlag == previewFlag);
           Repository<CMSHomePage> CMSHomePageRepository = new Repository<CMSHomePage>("PreviewFlag");
           CMSHomePage CMSHomePage= CMSHomePageRepository.SelectAll(CMSHomePageSpc).LastOrDefault();

           CMSHomePage.testimonials_content = !string.IsNullOrEmpty(CMSHomePageData.testimonials_content) ? CMSHomePageData.testimonials_content : CMSHomePage.testimonials_content;
           CMSHomePage.testimonials_Sign_Name = !string.IsNullOrEmpty(CMSHomePageData.testimonials_Sign_Name) ? CMSHomePageData.testimonials_Sign_Name : CMSHomePage.testimonials_Sign_Name;
           CMSHomePage.testimonials_Sign_CompanyName = !string.IsNullOrEmpty(CMSHomePageData.testimonials_Sign_CompanyName) ? CMSHomePageData.testimonials_Sign_CompanyName : CMSHomePage.testimonials_Sign_CompanyName;
           CMSHomePage.Blog_Header = !string.IsNullOrEmpty(CMSHomePageData.Blog_Header) ? CMSHomePageData.Blog_Header : CMSHomePage.Blog_Header;
           CMSHomePage.Blog_Content = !string.IsNullOrEmpty(CMSHomePageData.Blog_Content) ? CMSHomePageData.Blog_Content : CMSHomePage.Blog_Content;
           CMSHomePage.YoutubeSrc = !string.IsNullOrEmpty(CMSHomePageData.YoutubeSrc) ? CMSHomePageData.YoutubeSrc : CMSHomePage.YoutubeSrc;
           CMSHomePage.testimonials_imageName = !string.IsNullOrEmpty(CMSHomePageData.testimonials_imageName) ? CMSHomePageData.testimonials_imageName : CMSHomePage.testimonials_imageName;
          
           CMSHomePageRepository.Save();           
       }
    }
}
