using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDData.Implementations;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDLib;
using EknowIDData.Helper;

namespace TazWorksCom.HelperClasses
{
    public class CreditHelper
    {
        public static bool IsCreditIncluded(int OrderId)
        {
            bool isInclued = false;

            Repository<Order> repository = new Repository<Order>("OrderId");
            Order order = repository.SelectByKey(OrderId.ToString());

            if (order != null)
            {
                int planId = order.PlanId;
                if (planId != Constant.UNCOVER_YOUR_BACKGROUND_PLANID)
                {
                    ISpecification<PlanReport> sepecification = new Specification<PlanReport>(u => u.PlanId == planId);
                    Repository<PlanReport> repo = new Repository<PlanReport>();
                    IList<PlanReport> planReport = repo.SelectAll(sepecification);

                    foreach (PlanReport plnReport in planReport)
                    {
                        repo.LoadRelatedProperties(plnReport, new string[] { "Report" });

                        if (plnReport.Report.Name == Constant.CREDIT)
                        {
                            isInclued = true;
                            break;
                        }
                    }

                    if (!isInclued)
                    {
                        isInclued = IsAdditionallySelected(OrderId);
                    }
                }
                else
                {
                    isInclued = IsAdditionallySelected(OrderId);
                }
            }

            return isInclued;
        }

        private static bool IsAdditionallySelected(int OrderId)
        {
            bool isInclued = false;
            List<string> reportNames = OrderStatusHelper.GetAdditionalReportNameList(OrderId);
            foreach (string name in reportNames)
            {
                if (name == Constant.CREDIT)
                {
                    isInclued = true;
                    break;
                }
            }
            return isInclued;
        }
    }
}
