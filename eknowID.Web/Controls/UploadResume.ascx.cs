using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDLib;

namespace eknowID.Controls
{
    public partial class UploadResume : System.Web.UI.UserControl
    {
        public bool isResumeCheckerModule;
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.Url.ToString();
            //if (url.Contains("index.aspx") == true || url.Contains("SearchByProf_SelectProf.aspx") == true)
            //{
            //    isResumeCheckerModule = true;
            //}

            if (url.Contains("index.aspx") == true)
            { SessionWrapper.ModuleName = Constant.RESUME_CHECKER; }
         
          
        }
    }
}