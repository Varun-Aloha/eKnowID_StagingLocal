namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Candidate")]
    public partial class Candidate
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? CreatedOn { get; set; }
        
        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}
