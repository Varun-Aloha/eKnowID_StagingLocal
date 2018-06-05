namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DrugVerification")]
    public partial class DrugVerification
    {
        public DrugVerification()
        {
            DrugVerificationDetails = new HashSet<DrugVerificationDetail>();
        }

        public int DrugVerificationId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<DrugVerificationDetail> DrugVerificationDetails { get; set; }
    }
}
