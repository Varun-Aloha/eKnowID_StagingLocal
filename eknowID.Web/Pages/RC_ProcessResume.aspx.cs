using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDData.Helper.ResumeParser;
using System.IO;
using eknowID.AppCode;
using System.Drawing;
using EknowIDLib;
using Newtonsoft.Json;


namespace eknowID.Pages
{
    public partial class RC_ProcessResume : BasePage
    {
        string serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
        string userKey = ConfigurationManager.AppSettings["UserKey"];
        string version = ConfigurationManager.AppSettings["Version"];
        string subUserKey = ConfigurationManager.AppSettings["subUserKey"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnImportResume_Click(object sender, EventArgs e)
        {
            SessionWrapper.LinkedinData = null;
            SessionWrapper.ResumeParserData = null;

            //Set modual name to resume
            SessionWrapper.ModuleName = Constant.RESUME_CHECKER;

            string extension = Path.GetExtension(Server.MapPath(fileUploadResume.FileName));
            var mapPath = Server.MapPath(fileUploadResume.FileName);
            if (extension != null && mapPath != null)
            {               
                string fileName = mapPath.Replace(extension, DateTime.Now.ToString("yyyyMMddHHmmssfff")) + extension;
                fileName = fileName.Replace("Pages", "UploadResume");
                string filePath = Path.GetDirectoryName(fileName);
                if (filePath != null && !Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                fileUploadResume.PostedFile.SaveAs(fileName);
                ResumeParserHelper resumeParser = new ResumeParserHelper();
                resumeParser.ServiceUrl = serviceUrl;

                ResumeParserMapFields mapFields = resumeParser.ParseResume(fileName, userKey, version, subUserKey);

                try
                {
                    //RChilli.ResumeParserData resume = ResumeParserHelper.ParserResume(outPutJson);
                    SessionWrapper.ResumeParserData = new ResumeParserData();
                    SessionWrapper.ResumeParserData = mapFields.ResumeParserData;

                    if (SessionWrapper.ModuleName == Constant.RESUME_CHECKER)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "reloadPage", "RedirectToSpellCheck();", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "reloadPage", "ReloadPage();", true);
                    }

                }
                catch(Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                    lblErrorMessage.ForeColor = Color.Red;
                    lblErrorMessage.Visible = true;
                }                
            }
            else
            {

                lblErrorMessage.Text = "Invalid file type.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
            }
        }
    }
}