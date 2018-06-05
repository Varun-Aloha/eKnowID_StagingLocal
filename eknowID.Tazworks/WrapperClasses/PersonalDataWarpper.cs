using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Helper;


namespace TazWorksCom.WrapperClasses
{
   public class PersonalDataWarpper
    {
       private User _user;

       public PersonalDataWarpper(User user)
       {
           _user = user;
       }       

       public PersonalData GetXMLNode()
       {
           PersonalData personalData = new PersonalData();

           string region = StateHelper.GetStateById(_user.StateId).AlphaCode;
           
           personalData.PersonName = new PersonName();
           personalData.PersonName.GivenName = _user.FirstName;
           personalData.PersonName.MiddleName = _user.MiddleName;
           personalData.PersonName.FamilyName = _user.LastName;

           personalData.DemographicDetail = new DemographicDetail();
           personalData.DemographicDetail.DateOfBirth = DateTime.Parse(_user.Birthday.ToString()).ToShortDateString();
           personalData.DemographicDetail.GovernmentId = new GovernmentId();
           personalData.DemographicDetail.GovernmentId.Value =string.IsNullOrEmpty(_user.IdentificationValue)?null: Decryptdata(_user.IdentificationValue);       
           
           personalData.PostalAddress = new PostalAddress();
           personalData.PostalAddress.PostalCode = _user.Zip;
           personalData.PostalAddress.Region = region;
           personalData.PostalAddress.Municipality = region;
           personalData.PostalAddress.DeliveryAddress = new DeliveryAddress();           
           personalData.PostalAddress.DeliveryAddress.AddressLine = _user.Address1;
           personalData.PostalAddress.DeliveryAddress.StreetName = _user.Address2;

           personalData.EmailAddress = _user.Email;
           personalData.Telephone = _user.CellPhone;          

           return personalData;          
       }

       public static string Decryptdata(string encryptpwd)
       {
           string decryptpwd = string.Empty;
           UTF8Encoding encodepwd = new UTF8Encoding();
           Decoder Decode = encodepwd.GetDecoder();
           byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
           int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
           char[] decoded_char = new char[charCount];
           Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
           decryptpwd = new String(decoded_char);
           return decryptpwd;
       }


    }
}
