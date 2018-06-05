using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;

namespace eKnowID.Pages
{
    public partial class AboutUs : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Set page title,Meta Description, Meta Keywords
            Page.Title = "eKnowID | About Us | Innovative Technology | Compliant Focused | Money Back Guarantee";
            Page.MetaDescription = "eKnowID provides access to an online suite of background checking tools which are available to Employers, Housing authorities NOW to Individuals.";
            Page.MetaKeywords = "eKnowID, background check, background checks, self check, where to get background check";
        }
    }
}