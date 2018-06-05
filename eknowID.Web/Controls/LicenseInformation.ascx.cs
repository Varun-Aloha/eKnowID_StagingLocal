using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDModel;
using EknowIDData.Helper;
using System.Text.RegularExpressions;
using EknowIDData.Helper.UserProfileHelper;

namespace eknowID.Controls
{
    public partial class LicenseInformation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
                if (SessionWrapper.LoggedUser != null)
                {
                    SetUserLicenseInfo();                                
                }
           
        }

        private void SetUserLicenseInfo()
        {
            UserLicenseInfo userLicenseInfo = UserLicenseInfoHelper.GetUserLicenseInfoByUserId(SessionWrapper.LoggedUser.UserId);
            if (userLicenseInfo != null)
            {
                txtNumber.Text = userLicenseInfo.LicenseNumber;
                txtName.Text = userLicenseInfo.LicenseName;               
               // txtAgency.Text = userLicenseInfo.LicensingAgency;
                ddlStateLicense.Index = userLicenseInfo.StateId;

                ValidationRule validationRule = LicenseValidationHelper.GetValidationRuleById(StateHelper.GetStateById(userLicenseInfo.StateId).ValidationRuleId.Value);
                string regExp = validationRule.RegularExpression;
                regExp = regExp.Replace(@"\", @"\\");
                
                User user = UserHelper.GetUserById(SessionWrapper.LoggedUser.UserId);
                if (validationRule.IsLastCharcter)
                {
                    string lastCharacter = user.LastName[0].ToString();
                    regExp = regExp.Replace("[a-zA-Z]", lastCharacter);
                }
                string SSN = string.Empty;
                if (validationRule.IsSSN)
                {
                    SSN = user.IdentificationValue.Replace("-", string.Empty);
                }

                hdnIsLoggedIn.Value = "True";
                hdnIsSSN.Value = validationRule.IsSSN.ToString();
                hdnRegularExp.Value = validationRule.RegularExpression;
                hdnSSN.Value = SSN;
                hdnErrorMessage.Value = validationRule.Description;
              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "LicenseWrapper('" + regExp + "' ,'" + validationRule.IsSSN + "','" + true + "','" + SSN + "');", true);

              
            }
        }
    }
}