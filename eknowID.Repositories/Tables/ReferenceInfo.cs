namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReferenceInfo")]
    public partial class ReferenceInfo
    {
        public int ReferenceInfoId { get; set; }

        public int OrderId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Relationship { get; set; }

        [StringLength(30)]
        public string MobileNumber { get; set; }

        [StringLength(20)]
        public string YearsKnown { get; set; }

        public int ReferenceTypeId { get; set; }

        public virtual Order Order { get; set; }

        public virtual ReferenceType ReferenceType { get; set; }
    }
}
