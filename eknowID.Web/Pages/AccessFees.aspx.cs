using eknowID.AppCode;
using eknowID.MasterPages;
using eknowID.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages {
    public partial class AccessFees : System.Web.UI.Page, IAuthenticationRequired {
        public int? userType;
        PackageService packageService;

        public AccessFees() {
            packageService = new PackageService();
        }
        protected void Page_Load(object sender, EventArgs e) {
            userType = ((newMain)this.Master).userType;
            if (!Page.IsPostBack) {
                //var AccessFeesList = packageService.GetStateCriminalFeesList();
                rptStateCriminalFees.DataSource = packageService.GetStateCriminalFeesList();
                rptStateCriminalFees.DataBind();
                rptStateCountyAccessFees.DataSource = packageService.GetStateCountyFeesList();
                rptStateCountyAccessFees.DataBind();
                rptStateFederalAccessFees.DataSource = packageService.GetStateFederalFeesList();
                rptStateFederalAccessFees.DataBind();
                              
                ddlStates.DataTextField = "Name";
                ddlStates.DataValueField = "StateId";
                ddlStates.DataSource = packageService.GetStatesList();
                ddlStates.DataBind();
                //BindStateCriminalAccessFees();
            }
        }

        protected void loadStateCountyFees() {

        }

        [WebMethod]
        public static void GetStateCriminalAccessFees() {
            AccessFees obj = new AccessFees();
            obj.BindCountyCriminalAccessFees();
            
        }

        private void BindStateCriminalAccessFees() {            
            var AccessFeesList = packageService.GetStateCriminalFeesList();            
            rptStateCriminalFees.DataSource = AccessFeesList;
            rptStateCriminalFees.DataBind();
        }

        private void BindCountyCriminalAccessFees() {
            var AccessFeesList = packageService.GetStateCriminalFeesList();
            rptStateCountyAccessFees.DataSource = AccessFeesList;
            rptStateCountyAccessFees.DataBind();
        }


        [WebMethod]
        public static void AddUpdateStateCriminalAccessFees(int stateId, decimal accessFees, string avilability, string turnAroundTime) {
            var packageService = new PackageService();
            packageService.UpdateStateCriminalAccessFees(stateId, accessFees, avilability, turnAroundTime);
        }

        [WebMethod]
        public static void AddUpdateCountyCriminalAccessFees(int stateId, int countyId, string countyName, decimal accessFees) {
            var packageService = new PackageService();
            packageService.UpdateCountyCriminalAccessFees(stateId, countyId, countyName, accessFees);
        }

        [WebMethod]
        public static void AddUpdateFederalCriminalAccessFees(int stateId, int districtId, string districtName, decimal accessFees) {
            var packageService = new PackageService();
            packageService.UpdateFederalCriminalAccessFees(stateId, districtId, districtName, accessFees);
        }

        [WebMethod]
        public static void DeleteStateCriminalAccessFees(int stateId) {
            var packageService = new PackageService();
            packageService.DeleteStateCriminalAccessFees(stateId);
        }

        [WebMethod]
        public static void DeleteCountyCriminalAccessFees(int countyId) {
            var packageService = new PackageService();
            packageService.DeleteCountyCriminalAccessFees(countyId);
        }

        [WebMethod]
        public static void DeleteFederalCriminalAccessFees(int districtId) {
            var packageService = new PackageService();
            packageService.DeleteFederalCriminalAccessFees(districtId);
        }
    }
}