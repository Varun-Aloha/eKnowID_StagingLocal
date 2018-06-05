using eknowID.AppCode;
using EknowIDLib;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace eknowID.MasterPages
{
    public partial class newMain : System.Web.UI.MasterPage
    {
        public int? userType;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (this.Page is IAuthenticationRequired)
            {
                if (SessionWrapper.LoggedUser == null)
                {
                    hdnSessionFlag.Value = "false";
                    Response.Redirect("~/Pages/Index.aspx");
                }
            }
            if (SessionWrapper.LoggedUser != null)
            {
                hdnSessionFlag.Value = "true";
                lblRequesterName.Text = string.Format("{0} {1}", SessionWrapper.LoggedUser.FirstName, SessionWrapper.LoggedUser.LastName);

                //set Admin
                userType = SessionWrapper.LoggedUser.UserType;

                if (userType == null)
                {
                    userType = (int)UserTypeEnum.NORMAL_USER;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string fbLikeCount = string.Empty;

                fbLikeCount = GetFacebookCount();

                StringBuilder sb = new StringBuilder();
                sb.Append("<script type=text/javascript>");
                sb.Append("setFbCount('" + fbLikeCount + "');");
                sb.Append("</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
            }
            catch { }

            pnlLogin.Visible = SessionWrapper.LoggedUser == null;
            pnlLogout.Visible = SessionWrapper.LoggedUser != null;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            SessionWrapper.LoggedUser = null;

            var loggedOutPageUrl = string.Empty;

            if (this.Page is IAuthenticationRequired)
            {
                loggedOutPageUrl = "../Pages/Index.aspx";
            }
            else
            {
                loggedOutPageUrl = Request.RawUrl;
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory('" + loggedOutPageUrl + "');", true);
        }

        //Get Facebook Like count
        public static string get_web_content(string url)
        {
            string output = string.Empty;
            try
            {
                Uri uri = new Uri(url);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                request.Method = WebRequestMethods.Http.Get;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                output = reader.ReadToEnd();
                response.Close();
            }
            catch { }
            return output;
        }

        public string GetFacebookCount()
        {
            string request_url = "www.facebook.com/eknowid";
            request_url = Server.UrlEncode(request_url);

            string Facebook_raw_data = get_web_content(request_url);

            XmlDocument dom = new XmlDocument();
            dom.LoadXml(Facebook_raw_data);

            XmlNodeList root = dom.GetElementsByTagName("link_stat");

            string fbLikeCount = "";

            foreach (XmlNode node in root)
            {
                XmlElement companyElement = (XmlElement)node;
                fbLikeCount = companyElement.GetElementsByTagName("like_count")[0].InnerText;
            }

            int loopCount = 3;
            while (fbLikeCount.Length < loopCount)
            {
                fbLikeCount = "0" + fbLikeCount;
            }

            return fbLikeCount;
        }
    }
}