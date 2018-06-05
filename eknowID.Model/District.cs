
namespace EknowIDModel
{
    public class District
    {
        public virtual int DistrictId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual int StateId
        {
            get;
            set;
        }
        public virtual State State
        {
            get;
            set;
        }
        //public virtual List<User> Users
        //{
        //    get;
        //    set;
        //}
    }
}
