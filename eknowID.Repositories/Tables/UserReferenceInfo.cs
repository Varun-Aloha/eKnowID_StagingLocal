namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserReferenceInfo")]
    public partial class UserReferenceInfo
    {
        public int UserReferenceInfoId { get; set; }

        public int UserId { get; set; }

        public int? ReferenceTypeId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Relationship { get; set; }

        [StringLength(30)]
        public string MobileNumber { get; set; }

        [StringLength(20)]
        public string YearsKnown { get; set; }

        public virtual ReferenceType ReferenceType { get; set; }

        public virtual User User { get; set; }
    }
}
