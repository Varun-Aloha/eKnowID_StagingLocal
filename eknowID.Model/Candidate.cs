using EknowIDModel;
using System;

namespace eknowID.Model
{
    public class Candidate
    {
        public virtual Guid Id { get; set; }

        public virtual int UserId { get; set; }

        public virtual int OrderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public Guid AssessmentId { get; set; }

        public int Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public virtual User User { get; set; }

        public virtual Order Order { get; set; }
    }
}
