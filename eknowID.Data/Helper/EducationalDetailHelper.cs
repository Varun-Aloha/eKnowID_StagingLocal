using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper
{
    public class EducationalDetailHelper
    {
        public static EducationalDetail GetEducationalInfoByOrderId(int OrderId)
        {
            EducationalDetail educationalDetail = new EducationalDetail();
            Repository<EducationalDetail> educationalRepository = new Repository<EducationalDetail>("OrderId");
            educationalDetail = educationalRepository.SelectByKey(OrderId.ToString());
            return educationalDetail;        
        }

        public static PostGraduationDetail GetPostGraduationInfoByEducationInfoId(int educationDetailId) {
            PostGraduationDetail educationalDetail = new PostGraduationDetail();
            Repository<PostGraduationDetail> educationalRepository = new Repository<PostGraduationDetail>("EducationalDetailId");
            educationalDetail = educationalRepository.SelectByKey(educationDetailId.ToString());
            return educationalDetail;
        }

        public static List<EducationalDetail> GetEducationalDetailListByOrderId(int OrderId) {
            ISpecification<EducationalDetail> spc = new Specification<EducationalDetail>(u => u.OrderId == OrderId);
            Repository<EducationalDetail> repository = new Repository<EducationalDetail>();
        
            IList<EducationalDetail> educationInfoList = repository.SelectAll(spc);
            return (List<EducationalDetail>)educationInfoList;
        }
    }
}
