using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDModel;

namespace eknowID.Controls
{
    public partial class ResumeChecking_AlaCartReport : System.Web.UI.UserControl
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
                decimal d= Convert.ToDecimal(value.Price);
                String[] strVal = String.Format("{0:0.00}", value.Price).Split(new char[] { '.' }, StringSplitOptions.None);
                lblReportPrice.Text =d.ToString("C");
                reportDescription.InnerText = value.Description;
                reportDefaultDescription.InnerText = value.reportShortDesrript;
                hdnReportId.Value = value.ReportId.ToString();
                lblTurnaroundTime.Text = "(" + value.TurnaroundTime + ")";
            }
            private get
            {
                return _report;
            }
        }
    }
}