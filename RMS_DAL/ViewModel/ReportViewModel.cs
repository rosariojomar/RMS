using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class ReportViewModel
    {
    }

    public class ReportAnalyticsViewModel
    {
        public int NoOfBench { get; set; }
        public int PercentOfBench { get; set; }
        public int NoOfNonBench { get; set; }
        public int PercentOfNonBench { get; set; }
        public int TotalCountOfEmployee { get; set; }
    }


}
