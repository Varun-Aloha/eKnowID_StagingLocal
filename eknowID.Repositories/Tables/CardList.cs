namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CardList")]
    public partial class CardList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CardListId { get; set; }

        [StringLength(50)]
        public string CardType { get; set; }
    }
}
