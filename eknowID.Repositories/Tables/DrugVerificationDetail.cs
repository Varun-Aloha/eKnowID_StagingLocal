namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DrugVerificationDetail")]
    public partial class DrugVerificationDetail
    {
        public int DrugVerificationDetailId { get; set; }

        public int? DrugVerificationId { get; set; }

        [StringLength(50)]
        public string SpecimenId { get; set; }

        public int? OrderId { get; set; }

        public virtual DrugVerification DrugVerification { get; set; }

        public virtual Order Order { get; set; }
    }
}
