using System;
using System.Web.UI;
using eknowID.AppCode;
using System.Text;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class Feedback : BasePage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (hdnCaptchaVal.Value != txtcaptcha.Text && txtcaptcha.Text != string.Empty)
            {
                lblErrorCaptcha.Visible = true;
                txtcaptcha.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setCaptchaTxtFocus();", true);
            }
            imgcaptcha.ImageUrl = "captcha.aspx";
            string CaptchaText = (Guid.NewGuid().ToString()).Substring(0, 5);
            Response.Cookies["Captcha"]["value"] = CaptchaText;
            hdnCaptchaVal.Value = CaptchaText;

        }
        protected void LBcaptcha_Click(object sender, EventArgs e)
        {

            string CaptchaText = (Guid.NewGuid().ToString()).Substring(0, 5);
            Response.Cookies["Captcha"]["value"] = CaptchaText;
            hdnCaptchaVal.Value = CaptchaText;
            imgcaptcha.ImageUrl = "captcha.aspx";
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcaptcha.Text != string.Empty)
                {
                    //Send mail to support@eknowid.com
                    StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.FEEDBACK));
                    emailBody = emailBody.Replace(Constant.FEEDBACK_USER_MAILID, txtFeedbackEmailAddress.Text);
                    emailBody = emailBody.Replace(Constant.FEEDBACK_SUBJECT, txtFeedbackSubject.Text);
                    emailBody = emailBody.Replace(Constant.FEEDBACK_COMMENT, txtFeedbackMessage.Text);
                    SendMail.Sendmail(Constant.SUPPORT_EKNOWID_MAILID, Constant.FEEDBACK_MAIL_SUBJECT, emailBody.ToString());

                    //send mail to user
                    emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.REPLY_TO_FEEDBACK));

                    SendMail.Sendmail(txtFeedbackEmailAddress.Text, Constant.FEEDBACK_REPLY_MAIL_SUBJECT, emailBody.ToString());

                    lblErrorCaptcha.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "successPopup();", true);
                }
            }
            catch
            {
                lblErrorCaptcha.Text = "Error occurred.Please try again.";
                lblErrorCaptcha.Visible = true;
                txtcaptcha.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "setCaptchaTxtFocus();", true);
            }
        }
    }
}