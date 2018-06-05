using System.Collections.Generic;
using EknowIDModel.UserProfile;
using System;

namespace EknowIDModel
{
    public class State
    {
        public virtual int StateId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string AlphaCode
        {
            get;
            set;
        }

        public virtual List<User> Users
        {
            get;
            set;
        }
        
        public virtual List<EducationalDetail> EducationalDetails
        {
            get;
            set;
        }

        public virtual List<LicenseInfo> LicenseInfoes
        {
            get;
            set;
        }

        public virtual List<UserEducationalDetail> UserEducationalDetails
        {
            get;
            set;
        }
        public virtual List<UserLicenseInfo> UserLicenseInfoes
        {
            get;
            set;
        }
        public virtual List<EmploymentDetail> EmploymentDetails
        {
            get;
            set;
        }
        public virtual List<UserEmploymentDetail> UserEmploymentDetails
        {
            get;
            set;
        }
        public virtual List<PostGraduationDetail> PostGraduationDetails
        {
            get;
            set;
        }
        public virtual List<UserPostGraduation> UserPostGraduations
        {
            get;
            set;
        }

        public virtual List<County> Counties
        {
            get;
            set;
        }
        public virtual List<District> Districts
        {
            get;
            set;
        }

        public virtual List<StateCountyCourtFee> StateCountyCourtFees {
            get;
            set;
        }

        public virtual List<StateDistrictCourtFee> StateDistrictCourtFees {
            get;
            set;
        }

        //public virtual string RegularExpression
        //{
        //    get;
        //    set;
        //}

        public virtual ValidationRule ValidationRule
        {
            get;
            set;
        }
        public virtual int? ValidationRuleId
        {
            get;
            set;
        }
        public virtual List<CourtLocation> CourtLocations
        {
            get;
            set;
        }

    }

    public class StateCriminalCourtFee {
        public virtual int StateId {
            get;
            set;
        }

        public virtual string Name {
            get;
            set;
        }

        public virtual string AlphaCode {
            get;
            set;
        }

        public virtual string Availability {
            get;
            set;
        }

        public virtual bool Deleted {
            get;
            set;
        }
        public virtual Decimal? Fee {
            get;
            set;
        }

        public virtual string TurnAroundTime {
            get;
            set;
        }
    }

    public class StateCountyCourtFee {

        public virtual int Id {
            get;
            set;
        }
        public virtual int StateId {
            get;
            set;
        }

        public virtual string County {
            get;
            set;
        }

        public virtual Decimal? DistrictCourtFees {
            get;
            set;
        }

        public virtual Decimal? CircuitCourtFees {
            get;
            set;
        }

        public virtual Decimal? PerRecordFees {
            get;
            set;
        }

        public virtual bool IsYearly {
            get;
            set;
        }

        public virtual bool Deleted {
            get;
            set;
        }

        public virtual State State {
            get;
            set;
        }
    }

    public class StateDistrictCourtFee {

        public virtual int Id {
            get;
            set;
        }
        public virtual int StateId {
            get;
            set;
        }

        public virtual string DistrictCourt {
            get;
            set;
        }

        public virtual bool Deleted {
            get;
            set;
        }

        public virtual Decimal? DistrictCourtFees {
            get;
            set;
        }

        public virtual State State {
            get;
            set;
        }
    }
}
