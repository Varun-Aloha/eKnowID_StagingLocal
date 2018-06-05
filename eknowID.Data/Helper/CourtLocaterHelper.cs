using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper
{
   public class CourtLocaterHelper
    {
       public static List<CourtLocation> GetCourtList(int StateId,int CourtTypeId)
       {
           ISpecification<CourtLocation> specification = new Specification<CourtLocation>(sp => sp.StateId == StateId && sp.CourtTypeId == CourtTypeId);
           IRepository<CourtLocation> repository = new Repository<CourtLocation>();
           List<CourtLocation> courtLocations = (List<CourtLocation>) repository.SelectAll(specification);
           return courtLocations;          
       }
    }
}
