using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class ReferenceTypeHelper
    {
        public static int GetReferenceTypeIdByName(string name)
        {
            ISpecification<ReferenceType> refTypeSpec = new Specification<ReferenceType>(rt => rt.Name == name);
            Repository<ReferenceType> referenceRepo = new Repository<ReferenceType>("Name");
            ReferenceType referenceType = referenceRepo.SelectAll(refTypeSpec).FirstOrDefault();
            return referenceType.ReferenceTypeId;
        }   
    }
}
