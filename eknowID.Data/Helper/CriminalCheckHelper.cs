using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDData.Interfaces;
using EknowIDModel;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class CriminalCheckHelper
    {
        public static List<int> GetCriminalItems(int OrderId)
        {
            List<int> criminalNumber = new List<int>();
            Repository<Order> repository = new Repository<Order>("OrderId");
            Order order = repository.SelectByKey(OrderId.ToString());

            if(order != null)
            {
                int planId = order.PlanId;
                ISpecification<PlanReport> sepecification = new Specification<PlanReport>(u => u.PlanId == planId);
                Repository<PlanReport> repo = new Repository<PlanReport>();
                IList<PlanReport> planReport = repo.SelectAll(sepecification);

                if (planReport.Count != 0)
                {
                    for(int i=0; i<planReport.Count;i++)
                    {
                        int reportId = planReport[i].ReportId;
                        Repository<Report> repos = new Repository<Report>("ReportId");
                        Report report = repos.SelectByKey(reportId.ToString());

                        if (report.CriminalCheckNumber != 0)
                        {
                            criminalNumber.Add(report.CriminalCheckNumber);
                        }
                    }                 
                }
            }
            return criminalNumber;            
        }      
    }
}
