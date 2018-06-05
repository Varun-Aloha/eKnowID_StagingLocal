namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IdentificationType")]
    public partial class IdentificationType
    {
        public int IdentificationTypeId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }
    }
}
