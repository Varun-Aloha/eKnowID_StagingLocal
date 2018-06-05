namespace eknowID.Repositories
{
    using eknowID.Repositories.Tables;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Candidates = new HashSet<Candidate>();
            ForgotPasswords = new HashSet<ForgotPassword>();
            Orders = new HashSet<Order>();
            UserEducationalDetails = new HashSet<UserEducationalDetail>();
            UserEmploymentDetails = new HashSet<UserEmploymentDetail>();
            UserLicenseInfoes = new HashSet<UserLicenseInfo>();
            UserPostGraduations = new HashSet<UserPostGraduation>();
            UserReferenceInfoes = new HashSet<UserReferenceInfo>();
            UserSkills = new HashSet<UserSkill>();
            PaymentWalletHistorys = new HashSet<PaymentWalletHistory>();
            WalletBalances = new HashSet<WalletBalance>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(30)]
        public string Birthday { get; set; }

        public bool? Gender { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        public int? SecQuestionId { get; set; }

        [StringLength(100)]
        public string SecAnswer { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public int? StateId { get; set; }

        public int? CountyId { get; set; }

        public int? DistrictId { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        public int? AccountRefId { get; set; }

        public int? IdentificationTypeId { get; set; }

        [StringLength(50)]
        public string IdentificationValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }

        public int? UserType { get; set; }

        public bool? IsActive { get; set; }

        public int? CompanyId { get; set; }

        public Guid ActivationCode { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual ICollection<ForgotPassword> ForgotPasswords { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual SecQuestion SecQuestion { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<UserEducationalDetail> UserEducationalDetails { get; set; }

        public virtual ICollection<UserEmploymentDetail> UserEmploymentDetails { get; set; }

        public virtual ICollection<UserLicenseInfo> UserLicenseInfoes { get; set; }

        public virtual ICollection<UserPostGraduation> UserPostGraduations { get; set; }

        public virtual ICollection<UserReferenceInfo> UserReferenceInfoes { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }

        public virtual ICollection<PaymentWalletHistory> PaymentWalletHistorys { get; set; }

        public virtual ICollection<WalletBalance> WalletBalances { get; set; }
    }
}
