using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper
{
    public class StateHelper
    {
        public static State GetStateById(int? stateId)
        {
            Repository<State> stateRepository = new Repository<State>("StateId");
            return stateRepository.SelectByKey(stateId.ToString());
        }

        public static List<State> GetStateList()
        {            
            Repository<State> repository = new Repository<State>();
            IList<State> empDetailsList = repository.SelectAll();
            return (List<State>)empDetailsList; 
        }
    }
}
