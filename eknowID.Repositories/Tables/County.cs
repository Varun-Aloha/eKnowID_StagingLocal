namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("County")]
    public partial class County
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountyId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? StateId { get; set; }

        public virtual State State { get; set; }
    }
}
