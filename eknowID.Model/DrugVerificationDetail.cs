
namespace EknowIDModel
{
    public class DrugVerificationDetail
    {
        public virtual int DrugVerificationDetailId
        { get; set; }
        public virtual int DrugVerificationId
        { get; set; }
        public virtual string SpecimenId
        { get; set; }
        public virtual int OrderId
        { get; set; }

        public virtual DrugVerification DrugVerification
        {
            get;
            set;
        }
        public virtual Order Order
        {
            get;
            set;
        }
    }
}
