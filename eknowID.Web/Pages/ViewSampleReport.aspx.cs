using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class ViewSampleReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTab1_Click(object sender, EventArgs e)
        {
            mvReports.ActiveViewIndex = 0;
            tab1();
        }

        protected void btnTab2_Click(object sender, EventArgs e)
        {
            mvReports.ActiveViewIndex = 1;
            tab2();
        }

        protected void btnTab3_Click(object sender, EventArgs e)
        {
            mvReports.ActiveViewIndex = 2;
            tab3();
        }
        void tab1()
        {
            btnTab1.CssClass = "reportButtonClicked";
            btnTab2.CssClass = "reportButtonInitial";
            btnTab3.CssClass = "reportButtonInitial";

        }
        void tab2()
        {
            btnTab1.CssClass = "reportButtonInitial";
            btnTab2.CssClass = "reportButtonClicked";
            btnTab3.CssClass = "reportButtonInitial";
        }

        void tab3()
        {
            btnTab1.CssClass = "reportButtonInitial";
            btnTab2.CssClass = "reportButtonInitial";
            btnTab3.CssClass = "reportButtonClicked";

        }
    }
}