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
    public partial class OrderDetail : BasePage, IAuthenticationRequired
    {
        public bool isReferenceInfo;
        public bool isEmploymentDetails;
        public bool isLicenseDetails;
        public bool isEducationDetails;
        public bool isDrugVerificationReq;
        public bool isResumeCheckerModule;
        protected void Page_Load(object sender, EventArgs e)
        {
            isReferenceInfo = SessionWrapper.RequiredInformation.isReferenceInformationRequired;
            isEmploymentDetails = SessionWrapper.RequiredInformation.isEmploymentDetailsRequired;
            isLicenseDetails = SessionWrapper.RequiredInformation.isLicenseInformationRequired;
            isEducationDetails = SessionWrapper.RequiredInformation.isEducationDetailsRequired;
            isDrugVerificationReq = SessionWrapper.RequiredInformation.isDrugVerificationRequired;
            hdnDrugVerification.Value = isDrugVerificationReq.ToString();
            lblUserName.Text = SessionWrapper.LoggedUser.FirstName;          
            hdnModuleName.Value = SessionWrapper.ModuleName;

            isResumeCheckerModule = Request.UrlReferrer.AbsoluteUri.Contains("RC_DetailedAnalysis.aspx") == true ? true : false;    

            //Reset SpellErrorCheckData session if page not postback
            if (!IsPostBack)
            {
                SessionWrapper.ResumeRuleCheck = new ResumeRuleCheck();
            }
            if (SessionWrapper.ModuleName == Constant.UNCOVER_BACKGROUND)
            {
                ucSearchHeader.Visible = false;
                IdentityTheft_SearchByRef.Visible = true;

                Label lblSearchByProf = IdentityTheft_SearchByRef.FindControl("lblSelectByProf") as Label;
                lblSearchByProf.Text = "Import Profile";

                Label lblImport = IdentityTheft_SearchByRef.FindControl("lblImportInformation") as Label;
                lblImport.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

                Image imgBtnImport = IdentityTheft_SearchByRef.FindControl("imgBtnDot3") as Image;
                imgBtnImport.ImageUrl = "~/Images/color_hover_round.png";               
            }
            else
            {

                ucSearchHeader.Visible = true;
                IdentityTheft_SearchByRef.Visible = false;

                Label lblSearchByProf = ucSearchHeader.FindControl("lblSelectByProf") as Label;
                lblSearchByProf.Text = "Import Profile";

                Label lblImport = ucSearchHeader.FindControl("lblImportInformation") as Label;
                lblImport.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

                Image imgBtnImport = ucSearchHeader.FindControl("imgBtnDot3") as Image;
                imgBtnImport.ImageUrl = "~/Images/color_hover_round.png";
               
            }

          
        }
    }
}