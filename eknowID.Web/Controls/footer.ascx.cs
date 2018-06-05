using System;
using System.Web.UI;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;

namespace eknowID.Controls
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string request_url = "www.facebook.com/eknowid";
                request_url = Server.UrlEncode(request_url);
                request_url = "http://api.facebook.com/restserver.php?method=links.getStats&urls=" + request_url;
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
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type=text/javascript>");
                sb.Append("setFbCount('" + fbLikeCount + "');");
                sb.Append("</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
            }
            catch { }
        }

        //Get Facebook Like count
        public string get_web_content(string url)
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
    }
}