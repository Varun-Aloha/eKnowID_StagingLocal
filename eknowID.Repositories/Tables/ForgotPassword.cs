namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ForgotPassword")]
    public partial class ForgotPassword
    {
        public int ForgotPasswordId { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ForgotDate { get; set; }

        public bool? IsUsed { get; set; }

        public virtual User User { get; set; }
    }
}
