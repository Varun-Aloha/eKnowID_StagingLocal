using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EknowIDModel;
using EknowIDModel.UserProfile;

namespace eknowID.AppCode
{
    public class LinkedinData
    {
        public UserEducationalDetail EducationalDetail
        {
            get;
            set;
        }
        public UserPostGraduation Postgraduation
        {
            get;
            set;
        }

        public List<UserEmploymentDetail> EmploymentDetailes
        {
            get;
            set;
        }
    }
}