namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Log")]
    public partial class Log
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Thread { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Level { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string Logger { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4000)]
        public string Message { get; set; }
    }
}
