using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace EknowIDLib
{
    public class CreatePDF
    {
        private int OrderId;
        public CreatePDF(int orderId)
        {
            this.OrderId = orderId;
        }
        public void UrlTOPDF(String url)
        {
            Construct_Command(url);
        }

        private string footerurl = "https://eknowid.com/pages/footer.html";
        private string Headerurl = "https://eknowid.com/Pages/header.html";
        private string GetFilePath()
        {
            string path = string.Format("{0}{1}", Constant.CURRENT_DIRECTORY, "pdfs");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        private void Construct_Command(string WebUrl)
        {
            string str_Command = string.Empty;
            string Path = GetFilePath() + "\\" + OrderId.ToString() + ".pdf";
            if (!File.Exists(Path)) {
               string PDFFileName = OrderId.ToString() + ".pdf";

               str_Command = "--footer-html \"" + footerurl + "\" --header-html \"" + Headerurl + "\" --header-spacing 25 --margin-top 30  \"" + WebUrl + "\"  \"" + PDFFileName + "\"";

               Execute_Command(str_Command);
            }
        }

        public void Execute_Command(string str_Command)
        {
            try
            {
                var wkhtmltopdfPath = string.Format("{0}\\{1}", ProgramFilesx86(), "wkhtmltopdf\\bin\\wkhtmltopdf.exe");
                var procStartInfo = new ProcessStartInfo(wkhtmltopdfPath);
                procStartInfo.CreateNoWindow = true;
                procStartInfo.UseShellExecute = true;//This should not block your program
                procStartInfo.RedirectStandardError = false;
                procStartInfo.WorkingDirectory = GetFilePath();
                procStartInfo.Arguments = str_Command;

                using (var process = Process.Start(procStartInfo))
                {
                    process.WaitForExit();
                }
            }
            catch (Win32Exception ex)
            {
                // Log the exception
            }
            catch (Exception objException)
            {
                // Log the exception

            }
            catch { }
        }

        private bool IsUrlValid(string url)
        {
            return Regex.IsMatch(url, @"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }

        /// <summary>
        /// return OS programm file like 32 bit or 64 bit
        /// </summary>
        /// <returns></returns>
        private string ProgramFilesx86()
        {
            if (8 == IntPtr.Size || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }
    }
}