using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace EknowIDData.Helper.ResumeParser
{
    public class ResumeParserHelper
    {
        public String OutPutJson { get; set; }
        public String ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
        public String ServiceUrl { get; set; }
        public Boolean IsError { get; set; }

        public ResumeParserMapFields ParseResume(string filePath, string userKey, string version, string subUserId) {
            try {
                FileInfo file = new FileInfo(filePath);
                byte[] dataFile = ConvertToBase64(file);
                OutPutJson = ParseResumeBinary(Convert.ToBase64String(dataFile), file.Name, userKey, version, subUserId);
                if (OutPutJson.Contains("\"error\":")) {
                    IsError = true;
                    ErrorClass errorObj = JsonConvert.DeserializeObject<ErrorClass>(OutPutJson);
                    Error error = errorObj.error;
                    ErrorCode = error.errorcode.ToString();
                    ErrorMessage = error.errormsg;
                    throw new Exception(ErrorMessage);

                } else {
                    ResumeParserMapFields obj = JsonConvert.DeserializeObject<ResumeParserMapFields>(OutPutJson);
                    return obj;
                }

            } catch (Exception ex) {
                ErrorCode = "5001";
                ErrorMessage = ex.Message;
                throw new Exception(ErrorMessage);
            }
            return new ResumeParserMapFields();
        }

        string ParseResumeBinary(string base64String, string fileName, string userKey, string version, string subUserId) {

            String strRequest = "{\"filedata\":\"" + base64String + "\",\"filename\":\"" + fileName + "\",\"userkey\":\"" + userKey + "\",\"version\":\"" + version + "\",\"subuserid\":\"" + subUserId + "\"}";
            byte[] byteArray = Encoding.UTF8.GetBytes(strRequest);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(ServiceUrl);
            httpRequest.Credentials = CredentialCache.DefaultCredentials;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json;charset=utf-8";
            httpRequest.ContentLength = byteArray.Length;
            httpRequest.Timeout = 300000;
            Stream dataStream = httpRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string jsonData = streamReader.ReadToEnd();
            return jsonData;
        }


        public byte[] ConvertToBase64(FileInfo fno) {

            try {
                Int64 numofbyte = fno.Length;
                FileStream fs = new FileStream(fno.FullName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                byte[] dataFile = br.ReadBytes(Convert.ToInt32(numofbyte));
                fs.Close();
                fs.Dispose();
                return dataFile;
            } catch (Exception ex) {
                IsError = true;
                ErrorCode = "5000";
                ErrorMessage = "Exception occured" + ex.Message;
            }
            byte[] error1 = new byte[1];
            error1[0] = (byte)' ';
            return error1;
        }

        //public static string ParseResumeBinary(string base64String, string fileName, string userKey, string version, string serviceUrl, string subUserId)
        //{
        //    string jsonData = "";
        //    try
        //    {
        //        String strRequest = "{\"filedata\":\"" + base64String + "\",\"filename\":\"" + fileName + "\",\"userkey\":\"" + userKey + "\",\"version\":\"" + version + "\",\"subuserid\":\"" + subUserId + "\"}";
        //        byte[] byteArray = Encoding.UTF8.GetBytes(strRequest);
        //        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        httpRequest.Credentials = CredentialCache.DefaultCredentials;
        //        httpRequest.Method = "POST";
        //        httpRequest.ContentType = "application/json;charset=utf-8";
        //        httpRequest.ContentLength = byteArray.Length;
        //        httpRequest.Timeout = 300000;
        //        Stream dataStream = httpRequest.GetRequestStream();
        //        dataStream.Write(byteArray, 0, byteArray.Length);
        //        dataStream.Close();

        //        HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        //        StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.UTF8);
        //        jsonData = streamReader.ReadToEnd();
        //        return jsonData;
        //    }
        //    catch (Exception ex)
        //    {
        //    }           
        //    /////////////////API CALL PROCESS END///////////////////
        //    return jsonData;
        //}

        //public static ResumeParserData ParserResume(string xmlResponse)
        //{            
        //    ResumeParserData resumeData = (ResumeParserData)SerializationHelper.XmlDeserializeFromString(xmlResponse, typeof(ResumeParserData));
        //    return resumeData;
        //}

        public static error ParseError(string xmlResponse) {
            error errorMessage = (error)SerializationHelper.XmlDeserializeFromString(xmlResponse, typeof(error));
            return errorMessage;
        }
    }
}
