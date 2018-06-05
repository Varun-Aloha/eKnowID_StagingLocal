using System;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using EknowIDModel;
using EknowIDData.Helper.UserProfileHelper;
using System.IO;
using EknowIDData.Helper;
using System.ComponentModel;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using eknowID.Model;

namespace EknowIDLib
{
    public class SendMail
    {
        private static string GetFilePath()
        {
            return string.Format("{0}//{1}", Constant.CURRENT_DIRECTORY, "pdfs");
        }

        // Sending Mail to User with pdf Attachment 
        public static bool Sendmail(int orderid)
        {
            User user = UserHelper.GetUserByOrderId(orderid);
            Candidate candidate = UserHelper.GetCandidateByOrderId(orderid);
            string toAddress = user.Email;
            bool isSent = false;
            try
            {
                StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.STATUS_COMPLETE));
                emailBody = emailBody.Replace(Constant.CONST_FIRSTNAME, user.FirstName);
                emailBody = emailBody.Replace(Constant.CONST_LASTNAME, user.LastName);

                string subject = Constant.CONST_ORDERCOMPLETE_SUBJECT;
                subject = subject.Replace(Constant.CONST_ORDERID, orderid.ToString());
                MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(), toAddress, subject, emailBody.ToString());
                mail.IsBodyHtml = true;
                string PDF_File_Path = GetFilePath() + "\\" + orderid.ToString() + ".pdf";

                FileStream stream = File.OpenRead(PDF_File_Path);
               

                int length = Convert.ToInt32(stream.Length);
                byte[] data = new byte[length];
                stream.Read(data, 0, length);
                stream.Close();
                using (MemoryStream input = new MemoryStream(data)) {
                    using (MemoryStream output = new MemoryStream()) {
                        string password = candidate.Email;
                        PdfReader reader = new PdfReader(input);
                        PdfEncryptor.Encrypt(reader, output, true, password, password, PdfWriter.ALLOW_SCREENREADERS);
                        data = output.ToArray();                        
                    }
                }

                mail.Attachments.Add(new Attachment(new MemoryStream(data), orderid + ".pdf"));
                SmtpClient smtp = new SmtpClient();
                smtp.Send(mail);

                EmailSendLog emailSendLog = new EmailSendLog();
                emailSendLog.OrderId = orderid;
                emailSendLog.UserMailId = toAddress;
                emailSendLog.InsertTime = DateTime.Now;

                OrderHelper.SaveMailSendLog(emailSendLog);

                isSent = true;
            }
            catch (Exception ex) { }

            return isSent;
        }

        public static void SendWithAttachment(Email email) {
            var toUser = email.To.ToString().Split(',');
            var message = new MailMessage {
                IsBodyHtml = true,
                From = new MailAddress((string.IsNullOrEmpty(email.From) ? Constant.FromEmailAddress : email.From), email.DisplayName),
                Subject = email.Subject,
            };

            message.Attachments.Add(new Attachment(email.Attachment));

            Parallel.ForEach(toUser, user => {
                message.To.Add(user);
            });

            // smtp server
            var smtpclient = new SmtpClient();

            // send the mail
            smtpclient.Send(message);
        }

        public static bool Sendmail(int orderid, bool isStatusEnquiry)
        {
            User user = UserHelper.GetUserByOrderId(orderid);


            string toAddress = user.Email;
            bool isSent = false;
            try
            {
                StringBuilder emailBody = new StringBuilder(File.ReadAllText(ConfigurationManager.AppSettings["EmailFullPath"].ToString()));
                emailBody = emailBody.Replace(Constant.CONST_FIRSTNAME, user.FirstName);
                emailBody = emailBody.Replace(Constant.CONST_LASTNAME, user.LastName);

                string subject = Constant.CONST_ORDERCOMPLETE_SUBJECT;
                subject = subject.Replace(Constant.CONST_ORDERID, orderid.ToString());
                MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(), toAddress, subject, emailBody.ToString());
                mail.IsBodyHtml = true;
                string PDF_File_Path = GetFilePath() + "\\" + orderid.ToString() + ".pdf";
                FileStream stream = File.OpenRead(PDF_File_Path);
                mail.Attachments.Add(new Attachment(stream, orderid + ".pdf"));

                SmtpClient smtp = new SmtpClient();
                smtp.Send(mail);

                EmailSendLog emailSendLog = new EmailSendLog();
                emailSendLog.OrderId = orderid;
                emailSendLog.UserMailId = toAddress;
                emailSendLog.InsertTime = DateTime.Now;

                OrderHelper.SaveMailSendLog(emailSendLog);

                isSent = true;
            }
            catch (Exception ex) { }
            return isSent;
        }

        public static bool Sendmail(string ToAddress, string Subject, string Body)
        {
            bool isSent = false;
            try
            {
                MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(), ToAddress, Subject, Body);
                mail.IsBodyHtml = true;
                isSent = Sendmail(mail);
                isSent = true;
            }
            catch { }
            return isSent;
        }

        public static bool Sendmail(MailMessage Email)
        {
            bool isSent = false;
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Send(Email);

                isSent = true;
            }
            catch { }
            return isSent;
        }



        /// <summary>
        /// Create Email to send.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static void Send(Email email)
        {
            string emailBody = GetMailBody(email.EmailTemplate.GetDescription());
            emailBody = emailBody.Replace("[FirstName]", email.ReceiverFirstName);
            emailBody = emailBody.Replace("[LastName]", email.ReceiverLastName);
            emailBody = emailBody.Replace("[OfferName]", email.OfferName);
            emailBody = emailBody.Replace("[OfferPrice]", email.OfferPrice);
            emailBody = emailBody.Replace("[OfferList]", email.OfferList);
            emailBody = emailBody.Replace("[Company]", email.RequestingCompanyName);
            emailBody = emailBody.Replace("[AssessmentId]", email.AssessmentId.ToString());
            //emailBody = emailBody.Replace("[host]", Constant.Host);

            emailBody = emailBody.Replace("[CandidateName]", string.Format("{0} {1}", email.ReceiverFirstName, email.ReceiverLastName));
            Send(email, emailBody);
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="emailBody"></param>
        public static void Send(Email email, string emailBody)
        {
            var toUser = email.To.ToString().Split(',');
            var message = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress(email.From, email.DisplayName),
                Body = emailBody,
                Subject = email.Subject
            };

            Parallel.ForEach(toUser, user =>
            {
                message.To.Add(user);
            });

            message.CC.Add(email.CC);

            // smtp server
            var smtpclient = new SmtpClient();

            // send the mail
            smtpclient.Send(message);
        }

        /// <summary>
        /// Get Mail template by URL.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMailBody(string fileName)
        {
            return File.ReadAllText(Constant.EmailTemplatePath + fileName);
        }
    }
    public class Email
    {
        public Email()
        {

        }

        public Email(string to, string receiverFirstName, string receiverLastName, string requestingCompanyName, Guid assessmentId, EmailTemplate emailTemplate)
        {
            this.To = to;
            this.ReceiverFirstName = receiverFirstName;
            this.ReceiverLastName = receiverLastName;
            this.AssessmentId = assessmentId;
            this.EmailTemplate = emailTemplate;

            this.From = Constant.FromEmailAddress;
            this.CC = Constant.FromEmailAddress;
            this.Subject = Constant.EmailSubject;
            this.DisplayName = Constant.EmailDisplayName;
        }


        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string DisplayName { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string RequestingCompanyName { get; set; }
        public Guid AssessmentId { get; set; }
        public string OfferName { get; set; }
        public string OfferPrice { get; set; }
        public string OfferList { get; set; }
        public string Message { get; set; }
        public string ReceiverName { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
        public string Attachment { get; set; }
    }

    public enum EmailTemplate
    {
        [Description("applicant.html")]
        Applicant = 1,
        [Description("support.html")]
        Support = 2,
        [Description("requester.html")]
        requester = 3
    }
}
