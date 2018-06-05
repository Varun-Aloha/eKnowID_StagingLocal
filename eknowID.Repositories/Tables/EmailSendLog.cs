namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EmailSendLog")]
    public partial class EmailSendLog
    {
        [Key]
        public int LogId { get; set; }

        public int? OrderId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserMailId { get; set; }

        public DateTime InsertTime { get; set; }
    }
}
