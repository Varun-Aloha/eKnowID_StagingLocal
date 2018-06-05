using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDModel;
using EknowIDData.Helper.UserProfileHelper;
using System.Text;
using EknowIDLib;
using EknowIDData.Helper;

namespace eknowID.Controls
{
    public partial class OrderDetails_ContactInfo : System.Web.UI.UserControl
    {
        public int accoutType;
        public bool isSSNVisible;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SessionWrapper.LoggedUser != null)
                {
                    if (SessionWrapper.ResumeParserData == null)
                    {
                        SetContactInfo();
                    }
                    else
                    {
                        SetFromSessionData();
                    }
                }
            }
        }

        private void SetFromSessionData()
        {
            txtCntFname.Text = SessionWrapper.ResumeParserData.FirstName;
            txtCntMname.Text = SessionWrapper.ResumeParserData.Middlename;
            txtCntLname.Text = SessionWrapper.ResumeParserData.LastName;
            txtCntEmail.Text = SessionWrapper.LoggedUser.Email;
            txtCntMobile.Text = SessionWrapper.ResumeParserData.Phone;
            //txtCntIndentification.Text = ContactInfo.IdentificationValue;
            if (SessionWrapper.ResumeParserData.Gender == "Male")
            {
                rdbCntMale.Checked = true;
            }
            else
            {
                rdbCntFemale.Checked = true;
            }

            // txtCntDOB.Text = SessionWrapper.ResumeParserData.DateOfBirth;

            txtCntAddLine1.Text = SessionWrapper.ResumeParserData.Address;
            txtCntAddLine2.Text = SessionWrapper.ResumeParserData.Address;
            txtCntCity.Text = SessionWrapper.ResumeParserData.City;
            txtCntZip.Text = SessionWrapper.ResumeParserData.ZipCode;

            string identification = string.Empty;
            if (!IsSSNVisible())
            {
                ssnDiv.Style.Add("display", "none");
                identification = EncryptionHelper.Decryptdata(Constant.CONST_DEFAULT_ENCRYPT_SSN);
                txtSecurity1.Attributes["value"] = identification.Substring(0, 3);
                txtSecurity2.Attributes["value"] = identification.Substring(3, 2);
                txtSecurity3.Text = identification.Substring(5, 4);
                hdnSSN.Value = identification;

                txtConfirmSecurity1.Attributes["value"] = identification.Substring(0, 3);
                txtConfirmSecurity2.Attributes["value"] = identification.Substring(3, 2);
                txtConfirmSecurity3.Text = identification.Substring(5, 4);
                hdnConfirmSSN.Value = identification;


            }

        }

        private void SetContactInfo()
        {
            User ContactInfo = UserHelper.GetUserById(SessionWrapper.LoggedUser.UserId);
            if (ContactInfo != null)
            {
                accoutType = ContactInfo.AccountRefId.HasValue ? ContactInfo.AccountRefId.Value : 0;
                hdnAccountType.Value = accoutType.ToString();
                txtCntFname.Text = ContactInfo.FirstName;
                txtCntMname.Text = ContactInfo.MiddleName;
                txtCntLname.Text = ContactInfo.LastName;
                txtCntEmail.Text = ContactInfo.Email;
                txtCntMobile.Text = ContactInfo.CellPhone;
                //txtCntIndentification.Text = ContactInfo.IdentificationValue;

                string identification = ContactInfo.IdentificationValue;
                if (!string.IsNullOrEmpty(identification))
                {
                    identification = EncryptionHelper.Decryptdata(identification);
                    txtSecurity1.Attributes["value"] = identification.Substring(0, 3);
                    txtSecurity2.Attributes["value"] = identification.Substring(3, 2);
                    txtSecurity3.Text = identification.Substring(5, 4);
                    hdnSSN.Value = identification;

                    txtConfirmSecurity1.Attributes["value"] = identification.Substring(0, 3);
                    txtConfirmSecurity2.Attributes["value"] = identification.Substring(3, 2);
                    txtConfirmSecurity3.Text = identification.Substring(5, 4);
                    hdnConfirmSSN.Value = identification;
                }

                if (!IsSSNVisible())
                {
                    ssnDiv.Style.Add("display", "none");
                    identification = EncryptionHelper.Decryptdata(Constant.CONST_DEFAULT_ENCRYPT_SSN);
                    txtSecurity1.Attributes["value"] = identification.Substring(0, 3);
                    txtSecurity2.Attributes["value"] = identification.Substring(3, 2);
                    txtSecurity3.Text = identification.Substring(5, 4);
                    hdnSSN.Value = identification;

                    txtConfirmSecurity1.Attributes["value"] = identification.Substring(0, 3);
                    txtConfirmSecurity2.Attributes["value"] = identification.Substring(3, 2);
                    txtConfirmSecurity3.Text = identification.Substring(5, 4);
                    hdnConfirmSSN.Value = identification;


                }

                if (ContactInfo.Gender == false)
                {
                    rdbCntFemale.Checked = true;
                }
                else
                {
                    rdbCntMale.Checked = true;
                }

                //txtCntDOB.Text = ContactInfo.Birthday.HasValue ? ContactInfo.Birthday.Value.ToString("MM/dd/yyyy") : "";


                txtCntAddLine1.Text = ContactInfo.Address1;
                txtCntAddLine2.Text = ContactInfo.Address2;
                txtCntCity.Text = ContactInfo.City;
                ddlStateCnt.Index = ContactInfo.StateId.HasValue ? ContactInfo.StateId.Value : 0;
                txtCntZip.Text = ContactInfo.Zip;

                if (!string.IsNullOrEmpty(ContactInfo.Birthday))
                {
                    string[] dates = ContactInfo.Birthday.Split('-');

                    FillConatctInformation(dates[0], dates[1], dates[2]);
                }

            }
        }

        private void FillConatctInformation(string Month, string Day, string Year)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=text/javascript>");

            sb.Append("year.push('" + Year + "');");
            sb.Append("month.push('" + Month + "');");
            sb.Append("day.push('" + Day + "');");

            sb.Append("SetContactDetails();");
            sb.Append("</script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        }

        private bool IsSSNVisible()
        {
            int[] reportLst = { 2, 3, 4, 5, 14, 15, 17, 19, 20, 21 };

            foreach (int loopCount in SessionWrapper.AlacartReportList)
            {
                if (!reportLst.Contains(loopCount))
                    return true;
            }

            if (SessionWrapper.ModuleName != Constant.UNCOVER_BACKGROUND)
            {
                List<Report> selectedReportLst = PlanHelper.GetPlanReports(SessionWrapper.OrderDetail.PlanId);
                foreach (Report report in selectedReportLst)
                {
                    if (!reportLst.Contains(report.ReportId))
                        return true;
                }
            }
            return false;
        }
    }
}