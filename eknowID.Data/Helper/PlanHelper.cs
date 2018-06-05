using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class PlanHelper
    {
        public static List<Report> GetPlanReports(int planId)
        {
            List<Report> reports = new List<Report>();
            ISpecification<PlanReport> planSpc = new Specification<PlanReport>(pr => pr.PlanId == planId);
            IRepository<PlanReport> planRepRepository = new Repository<PlanReport>();
            IList<PlanReport> planreports = planRepRepository.SelectAll(planSpc);
            foreach (PlanReport planReport in planreports)
            {
                planRepRepository.LoadRelatedProperties(planReport, new string[] { "Report" });
                reports.Add(planReport.Report);
            }
            return reports;
        }

        public static List<Report> GetOptionalReports(int planId, int professionId)
        {
            List<Report> reports = GetPlanReports(planId);
            List<int> BasicReportIds = (from report in reports
                                        select report.ReportId).ToList<int>();

            List<Report> optionalReports = new List<Report>();

            ISpecification<ProfessionReport> proRepSpe = new Specification<ProfessionReport>(p => ((p.ProfessionId == professionId) && (!BasicReportIds.Contains(p.ReportId))));
            IRepository<ProfessionReport> proRepository = new Repository<ProfessionReport>();
            IList<ProfessionReport> professionReports = proRepository.SelectAll(proRepSpe);

            foreach (ProfessionReport professionReport in professionReports)
            {
                proRepository.LoadRelatedProperties(professionReport, new string[] { "Report" });
                optionalReports.Add(professionReport.Report);
            }

            return optionalReports;
        }

        public static Plan GetPlan(int planId)
        {
            IRepository<Plan> planRepository = new Repository<Plan>("PlanId");
            return planRepository.SelectByKey(planId.ToString());
        }

        public static List<Report> GetReportListByReportTypeId(int ReportTypeId)
        {
            List<Report> reports = new List<Report>();
            ISpecification<Report> planSpc = new Specification<Report>(pr => pr.ReportTypeID == ReportTypeId);
            IRepository<Report> planRepRepository = new Repository<Report>();
            IList<Report> planreports = planRepRepository.SelectAll(planSpc);
            return (List<Report>)planreports;
        }


        public static List<ReportList> GetPlanID(int profId)
        {
            ISpecification<ProfessionPlan> planSpe = new Specification<ProfessionPlan>(p => p.ProfessionId == profId);
            IRepository<ProfessionPlan> planRep = new Repository<ProfessionPlan>();
            IList<ProfessionPlan> professionPlans = planRep.SelectAll(planSpe);

            foreach (ProfessionPlan professionPlan in professionPlans)
            {
                planRep.LoadRelatedProperties(professionPlan, new string[] { "Plan" });
            }
            List<Report> basicReports = PlanHelper.GetPlanReports(professionPlans[0].PlanId);
            List<Report> goldReports = PlanHelper.GetPlanReports(professionPlans[1].PlanId);
            List<Report> platinumReports = PlanHelper.GetPlanReports(professionPlans[2].PlanId);

            List<ReportList> reportList = new List<ReportList>();
            reportList.Add(GetPlanData(professionPlans[0].Plan.Name, professionPlans[0].Plan.Rate, professionPlans[0].Plan.RateOff, basicReports, professionPlans[0].PlanId));
            reportList.Add(GetPlanData(professionPlans[1].Plan.Name, professionPlans[1].Plan.Rate, professionPlans[1].Plan.RateOff, goldReports, professionPlans[1].PlanId));
            reportList.Add(GetPlanData(professionPlans[2].Plan.Name, professionPlans[2].Plan.Rate, professionPlans[2].Plan.RateOff, platinumReports, professionPlans[2].PlanId));

            return reportList;
        }
        public static List<Report> GetReportList(int profId,int reportTypeID)
        {
            ISpecification<ProfessionReport> planSpe = new Specification<ProfessionReport>(p => p.ProfessionId == profId);
            IRepository<ProfessionReport> planRep = new Repository<ProfessionReport>();
            IList<ProfessionReport> professionReports = planRep.SelectAll(planSpe);
            List<Report> basicReports = new List<Report>();
            foreach (ProfessionReport professionReport in professionReports)
            {
                planRep.LoadRelatedProperties(professionReport, new string[] { "Report" });     
                if(professionReport.Report.ReportTypeID==reportTypeID)
                    basicReports.Add(professionReport.Report);
            }
            return basicReports;
        }
        public static ReportList GetPlanData(string PlanName, decimal Rate, int RateOff, List<Report> ReportList,int PlanID)
        {
            ReportList reportList = new ReportList();
            reportList.PlanName = PlanName;
            reportList.Rate = Rate;
            reportList.RateOff = RateOff;
            reportList.PlanID = PlanID;
            reportList.ReportNameList = new List<string>();
            foreach (Report report in ReportList)
            {
                reportList.ReportNameList.Add(report.Name);
            }

            return reportList;
        }
        public static List<Report> GetAlacartReportList()
        {
            Repository<Report> repos = new Repository<Report>();
            List<Report> reportList = repos.SelectAll().ToList<Report>();
            return reportList;
        }

        public static Report GetReportByReportID(int reportID)
        {
            Repository<Report> reportRep = new Repository<Report>("ReportId");
            return reportRep.SelectByKey(reportID.ToString());
        }
    }
}
