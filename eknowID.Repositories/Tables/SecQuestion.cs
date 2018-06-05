namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SecQuestion")]
    public partial class SecQuestion
    {
        public SecQuestion()
        {
            Users = new HashSet<User>();
        }

        public int SecQuestionId { get; set; }

        [StringLength(100)]
        public string Question { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
