using System.Collections.Generic;

namespace EknowIDModel
{
    public class CourtType
    {
       public virtual int CourtTypeId { get; set; }
       public virtual string Type { get; set; }
       public virtual List<CourtLocation> CourtLocations { get; set; }
    }
}
