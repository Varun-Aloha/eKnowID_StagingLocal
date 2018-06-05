using System.Collections.Generic;

namespace EknowIDModel
{
   public class DrugVerification
    {
      public virtual int  DrugVerificationId
      {
          get;
          set;
      }
      public virtual string Name
      {
          get;
          set;
      }
      public virtual List<DrugVerificationDetail> DrugVerificationDetails
      {
          get;
          set;
      }
    }
}
