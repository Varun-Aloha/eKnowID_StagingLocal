using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class GetStarted_UncoverBackground : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Set page title,Meta Description, Meta Keywords
            Page.Title = "eKnowID | Uncover your Background: Order a Check with eKnowID Now to See What's in Your Background";
            Page.MetaKeywords = "eKnowID, background check, background checks, tenant check, self check, criminal records, what is in a background check, record check";
            Page.MetaDescription = "Don't stay in the dark about your past. Order a self check today to know what is in your background check.";
        }
    }
}