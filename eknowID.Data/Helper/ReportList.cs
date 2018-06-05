using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDData.Helper
{
    public class ReportList
    {
        public string PlanName { get; set; }
        public List<string> ReportNameList { get; set; }
        public decimal Rate{get;set;}
        public int RateOff{get;set;}
        public int PlanID { get; set; }
    }
}
