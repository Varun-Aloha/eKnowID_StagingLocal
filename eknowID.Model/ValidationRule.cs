using System.Collections.Generic;

namespace EknowIDModel
{
    public class ValidationRule
    {
        public virtual int ValidationRuleId
        {
            get;
            set;
        }
        public virtual string Description
        {
            get;
            set;
        }
        public virtual string RegularExpression
        {
            get;
            set;
        }
        public virtual bool IsSSN
        {
            get;
            set;
        }
        public virtual bool IsLastCharcter 
        {
            get;
            set;
        }
        public virtual List<State> States
        {
            get;
            set;
        }
    }
}
