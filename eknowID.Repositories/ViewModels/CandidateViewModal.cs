using System;
using System.Collections.Generic;

namespace eknowID.Repositories.ViewModels
{
    public class CandidateViewModal
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
    }
}
