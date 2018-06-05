using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;

namespace EknowIDLib
{
   public class ConstructMail
    {
       public static string GetMailBody(String strEmail)
       {
           StringBuilder strFilePath = new StringBuilder(ConfigurationManager.AppSettings["EmailPath"].ToString());
           strFilePath = strFilePath.Append(strEmail);
           //return File.ReadAllText(strFilePath.ToString()).Replace(Constant.CONST_LOGO_PATH, ConfigurationManager.AppSettings["LogoPath"].ToString());
           
           return File.ReadAllText(HttpContext.Current.Server.MapPath(strFilePath.ToString()));
       }

    }
}
