using System;
using System.Collections.Generic;

namespace EknowIDModel
{
    public class IdentificationType
    {
        public virtual int IdentificationTypeId
        {
            get;
            set;
        }

        public virtual String Name
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
