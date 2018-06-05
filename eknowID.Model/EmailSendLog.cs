using System;

namespace EknowIDModel
{
    public class EmailSendLog
    {
        public int LogId
        {
            get;
            set;
        }

        public int OrderId
        {
            get;
            set;
        }
        public string UserMailId
        {
            get;
            set;
        }
        public DateTime InsertTime
        {
            get;
            set;
        }
    }
}
