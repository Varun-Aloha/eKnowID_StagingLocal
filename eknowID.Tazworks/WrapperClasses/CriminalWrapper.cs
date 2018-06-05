using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;
using EknowIDModel;
using EknowIDData.Helper;

namespace TazWorksCom.WrapperClasses
{
    public class CriminalWrapper
    {
        private User _user;
        private string _state;
        private string _county;
        //private string _district;

        public CriminalWrapper()
        {
          
        }
        public CriminalWrapper(User User)
        {
            _user = User;
        }
        public CriminalWrapper(string State, string County)
        {
            _state = State;
            _county = County;
        }
        public CriminalWrapper(string State)
        {
            _state = State;            
        }

        //public CriminalWrapper(string District,string State)
        //{
        //    _state = State;
        //    _district = District;
        //}

        public CountyCriminalScreening GetCountyCriminalNode()
        {      
            CountyCriminalScreening countyCriminal = new CountyCriminalScreening();
            //string region = StateHelper.GetStateById(_user.StateId).AlphaCode;
            //string county = CountyHelper.GetCountyById(_user.CountyId).Name;
            //countyCriminal.Region = region;
            //countyCriminal.County = county;
            //dummy values need to change 
            //countyCriminal.Region = "WA";
            //countyCriminal.County = "KING";
            return countyCriminal;
        }

        public FederalCriminalScreening GetFederalCriminalNode()
        {
            FederalCriminalScreening federalCriminal = new FederalCriminalScreening();
            string region = StateHelper.GetStateById(_user.StateId).AlphaCode;
            //federalCriminal.Region = region;
            //federalCriminal.District  = _user.District;
            //dummy values need to change
            //federalCriminal.Region = "PA";
            //federalCriminal.District = "Middle";

            return federalCriminal;
        }

        public InstaCriminalSingleStateScreening GetSingleStateCriminalNode()
        {
            InstaCriminalSingleStateScreening singleState = new InstaCriminalSingleStateScreening();
            string region = StateHelper.GetStateById(_user.StateId).AlphaCode;
            singleState.Region = region;            
            return singleState;
        }

        public InstaCriminalMultiStateScreening GetMultiStateCriminalNode()
        {
            InstaCriminalMultiStateScreening multiState = new InstaCriminalMultiStateScreening();
            return multiState;
        }

        public StateCriminalScreening GetStateCriminalNode()
        {
            StateCriminalScreening stateScreening = new StateCriminalScreening();
            string region = StateHelper.GetStateById(_user.StateId).AlphaCode;
            stateScreening.Region = region;
            return stateScreening ;
        }
        public InternationalCriminalScreening GetInternationalCriminalNode()
        {
            InternationalCriminalScreening internationalScreening = new InternationalCriminalScreening();
            //string region = StateHelper.GetStateById(_user.StateId).AlphaCode;
            //internationalScreening.Region = region;
            return internationalScreening;
        }
    }
}
