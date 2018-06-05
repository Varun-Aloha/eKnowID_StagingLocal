using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;

namespace eknowID.Pages
{
    public partial class WhyEKnowID : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Set page title,Meta Description, Meta Keywords
            Page.Title = "Why eKnowID? | Searches Done Right | Affordable | Respect for privacy";
            Page.MetaDescription = "We at eKnowID ensure that the checks we offer are not only easy to order but aslo affordable. We respect your privacy as well!";
            Page.MetaKeywords = "eKnowID, background check, background checks, self check, affordable backgrond checks";
        }
    }
}