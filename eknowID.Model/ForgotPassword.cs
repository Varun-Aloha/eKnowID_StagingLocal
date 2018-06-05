using System;

namespace EknowIDModel
{
    public class ForgotPassword
    {
        public virtual int ForgotPasswordId
        {
            get;
            set;
        }
        public virtual int UserId
        {
            get;
            set;
        }
        public virtual DateTime ForgotDate
        {
            get;
            set;
        }
        public virtual bool IsUsed
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }
    }
}
