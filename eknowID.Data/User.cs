//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eknowID.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Candidates = new HashSet<Candidate>();
            this.ForgotPasswords = new HashSet<ForgotPassword>();
            this.Orders = new HashSet<Order>();
            this.PaymentWalletHistories = new HashSet<PaymentWalletHistory>();
            this.UserEducationalDetails = new HashSet<UserEducationalDetail>();
            this.UserEmploymentDetails = new HashSet<UserEmploymentDetail>();
            this.UserLicenseInfoes = new HashSet<UserLicenseInfo>();
            this.UserPostGraduations = new HashSet<UserPostGraduation>();
            this.UserReferenceInfoes = new HashSet<UserReferenceInfo>();
            this.UserSkills = new HashSet<UserSkill>();
            this.WalletBalances = new HashSet<WalletBalance>();
        }
    
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birthday { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string CellPhone { get; set; }
        public Nullable<int> SecQuestionId { get; set; }
        public string SecAnswer { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountyId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public string Zip { get; set; }
        public Nullable<int> AccountRefId { get; set; }
        public Nullable<int> IdentificationTypeId { get; set; }
        public string IdentificationValue { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> IsAdmin { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public System.Guid ActivationCode { get; set; }
    
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<ForgotPassword> ForgotPasswords { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PaymentWalletHistory> PaymentWalletHistories { get; set; }
        public virtual SecQuestion SecQuestion { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<UserEducationalDetail> UserEducationalDetails { get; set; }
        public virtual ICollection<UserEmploymentDetail> UserEmploymentDetails { get; set; }
        public virtual ICollection<UserLicenseInfo> UserLicenseInfoes { get; set; }
        public virtual ICollection<UserPostGraduation> UserPostGraduations { get; set; }
        public virtual ICollection<UserReferenceInfo> UserReferenceInfoes { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<WalletBalance> WalletBalances { get; set; }
    }
}