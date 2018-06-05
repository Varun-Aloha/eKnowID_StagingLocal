using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;

namespace eknowID.Pages
{
    public partial class HowItWork : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set page title,Meta Description, Meta Keywords
            Page.Title = "eKnowID | How it Works | Choose a Package | We Process your Background Check | You Receive your Report";
            Page.MetaDescription = "eKnowID provides you with a choice of packages to pick from. Order one that fulfils your needs and let us process your background check.";
            Page.MetaKeywords = "eKnowID, background check, background checks, self check, how can i get a background check, how to run a background check";
        }
    }
}