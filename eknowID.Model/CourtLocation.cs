
namespace EknowIDModel
{
   public class CourtLocation
    {
      public virtual int CourtLocationId { get; set; }
      public virtual string OfficeName { get; set; }
      public virtual int CityId { get; set; }
      public virtual int CourtTypeId { get; set; }
      public virtual int StateId { get; set; }
      public virtual City City { get; set; }
      public virtual CourtType CourtType { get; set; }
      public virtual State State { get; set; }
    }
}
