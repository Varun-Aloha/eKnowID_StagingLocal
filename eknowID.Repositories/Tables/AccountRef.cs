namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AccountRef")]
    public partial class AccountRef
    {
        public int AccountRefId { get; set; }

        [StringLength(10)]
        public string Name { get; set; }
    }
}
