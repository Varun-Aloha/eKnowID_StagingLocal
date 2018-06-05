using System.Collections.Generic;

namespace EknowIDModel
{
    public class SecQuestion
    {
        public int SecQuestionId { 
            get; set; 
        }

        public string Question
        {
            get;
            set;
        }

        public virtual List<User> Users
        {
            get;
            set;
        }
    }
}
