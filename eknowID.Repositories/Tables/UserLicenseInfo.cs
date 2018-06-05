namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserLicenseInfo")]
    public partial class UserLicenseInfo
    {
        public int UserLicenseInfoId { get; set; }

        public int UserId { get; set; }

        public int? StateId { get; set; }

        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [StringLength(50)]
        public string LicenseName { get; set; }

        [StringLength(50)]
        public string LicensingAgency { get; set; }

        public virtual State State { get; set; }

        public virtual User User { get; set; }
    }
}
