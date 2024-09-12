using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Service.Impl
{
    public class ReportService : IReportService
    {
        private readonly RMSContext _context;

        public ReportService(RMSContext context)
        {
            _context = context;
        }

        public ReportAnalyticsViewModel GetAnalytics()
        {
            var benchCount = _context.People.Where(x => x.IsBench == true).Count();
            var nonBenchCount = _context.People.Where(x => x.IsBench == false).Count();
            var totalEmployee = _context.People.Where(x => x.IsActive == true).Count();
            var totalCount = benchCount + nonBenchCount;
            var benchPercent = totalCount / benchCount; 
            var nonBenchPercent = totalCount / nonBenchCount;

            ReportAnalyticsViewModel reportModel = new ReportAnalyticsViewModel()
            {
                NoOfBench = benchCount,
                NoOfNonBench = nonBenchCount,
                PercentOfBench = benchPercent,
                PercentOfNonBench = nonBenchPercent,
                TotalCountOfEmployee = totalEmployee,
            };

            return (ReportAnalyticsViewModel)reportModel;
        }


    }
}
