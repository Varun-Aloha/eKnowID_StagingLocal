namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LicenseInfo")]
    public partial class LicenseInfo
    {
        public int LicenseInfoId { get; set; }

        public int OrderId { get; set; }

        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [StringLength(50)]
        public string LicenseName { get; set; }

        [StringLength(50)]
        public string LicensingAgency { get; set; }

        public int? StateId { get; set; }

        public virtual Order Order { get; set; }

        public virtual State State { get; set; }
    }
}
