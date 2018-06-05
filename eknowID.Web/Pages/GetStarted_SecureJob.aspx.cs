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
    public partial class GetStarted_SecureJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set page title,Meta Description, Meta Keywords
            Page.Title = "eKnowID | Secure a Job | Need Help Finding a Job? Order an Employment Background Check on eKnowID Today to See What Employers See!";
            Page.MetaKeywords = "eKnowID, background check, background checks, employment verification, self check, free resume analysis, employment background check. resume check, record check, job seekers";
            Page.MetaDescription = "Mistakes and outdated information in your employment verification can cost you a job. Take proactive measures by ordering an employment background check with the help of eKnowID.";
        }
    }
}