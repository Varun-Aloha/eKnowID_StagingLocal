using eknowID.AppCode;
using eknowID.MasterPages;
//using eknowID.Repositories;
using eknowID.Services;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDLib;
using EknowIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages {
    public partial class AddOnSearches : System.Web.UI.Page, IAuthenticationRequired {
        public int? userType;
        PackageService packageService;

        public AddOnSearches() {
            packageService = new PackageService();
        }
        protected void Page_Load(object sender, EventArgs e) {
            userType = ((newMain)this.Master).userType;
            if (!Page.IsPostBack) {
                if (userType == (int)UserTypeEnum.SUPER_ADMIN) {
                    BindReportsGrid();
                }
            }
            IRepository<ReportType> repository = new Repository<ReportType>();
            IList<ReportType> drugs = repository.SelectAll();
            ddlReprotType.DataTextField = "ReportTypeName";
            ddlReprotType.DataValueField = "ReportTypeID";
            ddlReprotType.DataSource = drugs;
            ddlReprotType.DataBind();            
        }

        public void BindReportsGrid() {
            List<eknowID.Repositories.Report> reportLst = packageService.GetAlacartReport();
            rptReports.DataSource = reportLst;
            rptReports.DataBind();
        }

        [WebMethod]
        public static bool AddUpdateReportDetails(eknowID.Repositories.Report report) {
            var packageService = new PackageService();
            return packageService.AddUpdateReportDetail(report);
        }

        [WebMethod]
        public static bool DeleteReport(int reportId) {
            var packageService = new PackageService();
            return packageService.DeleteReport(reportId);
        }
    }
}