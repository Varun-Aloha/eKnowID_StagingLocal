using System.Collections.Generic;

namespace EknowIDModel
{
    public class City
    {
        public virtual int CityId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Zip { get; set; }
        //public virtual int StateId { get; set; }
        //public virtual State State { get; set; }

        public virtual List<CourtLocation> CourtLocations
        {
            get;
            set;
        }
    }
}
