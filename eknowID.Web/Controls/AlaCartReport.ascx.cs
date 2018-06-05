using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDModel;

namespace eknowID.Controls
{
    public partial class AlaCartReport : System.Web.UI.UserControl
    {
        public Report _report;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Report report
        {
            set
            {
                _report = value;
                lblReportName.Text = value.Name;
                if(value.Name.ToLower().Contains("credit report")) {
                    chkReportName.Enabled = false;
                    chkReportName.ToolTip = "You can do individual credit report search at https://www.annualcreditreport.com/";
                    spanIndividualCreditReprotSearch.InnerText = "For individual credit report search go to ";
                    linkIndividualCreditReprotSearch.HRef = "https://www.annualcreditreport.com/";
                    linkIndividualCreditReprotSearch.InnerText = "https://www.annualcreditreport.com/";
                    //reportTitleSpan.Visible = true;
                    //chkReportName.Attributes("class", "creditreportsearch");
                }
                decimal d= Convert.ToDecimal(value.Price);
                String[] strVal = String.Format("{0:0.00}", value.Price).Split(new char[] { '.' }, StringSplitOptions.None);
                lblReportPrice.Text =d.ToString("C");
                reportDetails.InnerText = value.Description;
                hdnReportId.Value = value.ReportId.ToString();
                hdnReportPrice.Value = d.ToString();
                hdnMultipleCheckEnabled.Value = value.IsMultipleCheckEnabled.ToString();
                hdnMaxVerificationCount.Value = value.MaxVerificationCount.ToString(); 
                lblTurnaroundTime.Text = "(" + value.TurnaroundTime + ")";
            }
            private get
            {
                return _report;
            }
        }
    }
}