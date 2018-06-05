using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eknowID.AppCode
{
    public class PageReportData
    {
        public PageReportData(String reportName, string description)
        {
            ReportName = reportName;
            Description = description;
        }

        public PageReportData(String reportName, string description,int reportId,decimal? price)
        {
            ReportName = reportName;
            Description = description;
            ReportId = reportId;
            Price = price;
        }
        public string ReportName { get; set; }
        public string Description { get; set; }
        public int ReportId { get; set; }
        public decimal? Price { get; set; }
    }

   
}