using System.Collections.Generic;

namespace EknowIDModel
{
    public class AccountRef
    {
        public virtual int AccountRefId
        {
            get;
            set;
        }

        public virtual string Name
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
