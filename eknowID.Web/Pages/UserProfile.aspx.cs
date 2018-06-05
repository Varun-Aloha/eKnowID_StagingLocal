using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDModel;
using EknowIDData.Helper;

namespace eknowID.Pages
{
    public partial class UserProfile :BasePage, IAuthenticationRequired
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserName.Text = SessionWrapper.LoggedUser.FirstName;
            SessionWrapper.ModuleName = string.Empty;
        }

        //protected void btnRChecker_Click(object sender, EventArgs e)
        //{
        //    //fileUploadResume.PostedFile.SaveAs(Server.MapPath(fileUploadResume.FileName));
        //    //FileInfo file = new FileInfo(Server.MapPath(fileUploadResume.FileName));
        //    //Int64 numofbyte = file.Length;
        //    //FileStream fs = new FileStream(Server.MapPath(fileUploadResume.FileName), FileMode.Open);
        //    //BinaryReader br = new BinaryReader(fs);
        //    //byte[] DataFile = br.ReadBytes(Convert.ToInt32(numofbyte));
        //    //ResumeParserData resume = ResumeParserHelper.ParserResume(Convert.ToBase64String(DataFile), file.Extension.ToString(), "9ZCWH5EEBNH", "4.0", "http://saas.rchilli.com/rchilli.asmx", "SRW7P97B75EKS5SE27EM", "Aloha Technology");            
        //}
    }
}