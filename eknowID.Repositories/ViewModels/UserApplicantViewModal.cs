
using System;
namespace eknowID.Repositories.ViewModels
{
    public class UserApplicantViewModal
    {
        public Company Company { get; set; }
        public User User { get; set; }
        public Candidate Candidate { get; set; }
    }

    public class UserViewModal
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CompayId { get; set; }
    }
}
