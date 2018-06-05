namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionLog")]
    public partial class TransactionLog
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LogDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
