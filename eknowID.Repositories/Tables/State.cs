namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("State")]
    public partial class State
    {
        public State()
        {
            Counties = new HashSet<County>();
            CourtLocations = new HashSet<CourtLocation>();
            Districts = new HashSet<District>();
            EducationalDetails = new HashSet<EducationalDetail>();
            EmploymentDetails = new HashSet<EmploymentDetail>();
            LicenseInfoes = new HashSet<LicenseInfo>();
            PostGraduationDetails = new HashSet<PostGraduationDetail>();
            Users = new HashSet<User>();
            UserEducationalDetails = new HashSet<UserEducationalDetail>();
            UserEmploymentDetails = new HashSet<UserEmploymentDetail>();
            UserLicenseInfoes = new HashSet<UserLicenseInfo>();
            StateCountyCourtFees = new HashSet<StateCountyCourtFee>();
            StateDistrictCourtFees = new HashSet<StateDistrictCourtFee>();
        }

        public int StateId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(2)]
        public string AlphaCode { get; set; }

        public int? ValidationRuleId { get; set; }

        public virtual ICollection<County> Counties { get; set; }

        public virtual ICollection<CourtLocation> CourtLocations { get; set; }

        public virtual ICollection<District> Districts { get; set; }

        public virtual ICollection<EducationalDetail> EducationalDetails { get; set; }

        public virtual ICollection<EmploymentDetail> EmploymentDetails { get; set; }

        public virtual ICollection<LicenseInfo> LicenseInfoes { get; set; }

        public virtual ICollection<PostGraduationDetail> PostGraduationDetails { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<UserEducationalDetail> UserEducationalDetails { get; set; }

        public virtual ICollection<UserEmploymentDetail> UserEmploymentDetails { get; set; }

        public virtual ICollection<UserLicenseInfo> UserLicenseInfoes { get; set; }

        public virtual ValidationRule ValidationRule { get; set; }

        public virtual ICollection<StateCountyCourtFee> StateCountyCourtFees { get; set; }

        public virtual ICollection<StateDistrictCourtFee> StateDistrictCourtFees { get; set; }
    }
}
