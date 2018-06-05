using System;
using System.Collections.Generic;
using EknowIDModel.UserProfile;
using eknowID.Model;

namespace EknowIDModel
{
    public class User
    {
        public virtual int UserId
        {

            get;
            set;
        }

        public virtual string FirstName
        {
            get;
            set;
        }

        public virtual string MiddleName
        {
            get;
            set;
        }

        public virtual string LastName
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string Password
        {
            get;
            set;
        }

        public virtual string Birthday
        {
            get;
            set;
        }

        public virtual Boolean? Gender
        {
            get;
            set;
        }

        public virtual String CellPhone
        {
            get;
            set;
        }

        public virtual int? IsAdmin { get; set; }

        public virtual int? SecQuestionId
        {
            get;
            set;
        }

        public virtual string SecAnswer
        {
            get;
            set;
        }

        public virtual string Address1
        {
            get;
            set;
        }

        public virtual string Address2
        {
            get;
            set;
        }

        public virtual string City
        {
            get;
            set;
        }

        public virtual int? StateId
        {
            get;
            set;
        }
        public virtual int CountyId
        {
            get;
            set;
        }
        public virtual int DistrictId
        {
            get;
            set;
        }
        public virtual string Zip
        {
            get;
            set;
        }

        public virtual int? AccountRefId
        {
            get;
            set;
        }

        public int? UserType
        {
            get;
            set;
        }

        public bool? IsActive
        {
            get;
            set;
        }

        public int? CompanyId
        {
            get;
            set;
        }

        public Guid ActivationCode {
            get;
            set;
        }

        public virtual AccountRef AccountRef
        {
            get;
            set;
        }

        public virtual State State
        {
            get;
            set;
        }
        //public virtual District District
        //{
        //    get;
        //    set;
        //}
        //public virtual County County
        //{
        //    get;
        //    set;
        //}

        public virtual SecQuestion SecQuestion
        {
            get;
            set;
        }

        public virtual int IdentificationTypeId
        {
            get;
            set;
        }

        public virtual string IdentificationValue
        {
            get;
            set;
        }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime? LastLoginDate { get; set; }

        public virtual IdentificationType IdentificationType
        {
            get;
            set;
        }

        public virtual Company Company
        {
            get;
            set;
        }

        public virtual List<Order> Orders
        {
            get;
            set;
        }
        public virtual List<UserEducationalDetail> UserEducationalDetails
        {
            get;
            set;
        }

        public virtual List<UserLicenseInfo> UserLicenseInfoes
        {
            get;
            set;
        }

        public virtual List<UserSkill> UserSkills
        {
            get;
            set;
        }
        public virtual List<UserEmploymentDetail> UserEmploymentDetails
        {
            get;
            set;
        }
        public virtual List<UserReferenceInfo> UserReferenceInfoes
        {
            get;
            set;
        }
        public virtual List<UserPostGraduation> UserPostGraduations
        {
            get;
            set;
        }

        public virtual List<ForgotPassword> ForgotPasswords
        {
            get;
            set;
        }

        public virtual List<Candidate> Candidates
        {
            get;
            set;
        }

        public virtual List<WalletBalance> WalletBalances
        {
            get;
            set;
        }

        public virtual List<PaymentWalletHistory> PaymentWalletHistories
        {
            get;
            set;
        }
    }
}
