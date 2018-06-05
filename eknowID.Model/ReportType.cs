using System.Collections.Generic;

namespace EknowIDModel
{
    public class ReportType
    {
        public int ReportTypeID
        { get; set; }
        public string ReportTypeName { get; set; }
        List<Report> Reports { get; set; }
    }
}
