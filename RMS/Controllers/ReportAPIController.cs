using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.RMSDBContext;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportAPIController : ControllerBase
    {
        private readonly ReportService _reportService;
        public ReportAPIController(RMSContext context)
        {
            _reportService = new ReportService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllDivisionActive()
        {
            var reportModel = _reportService.GetAnalytics();
            var result = string.Empty;
            if (reportModel.TotalCountOfEmployee != 0)
            {
                result = JsonConvert.SerializeObject(reportModel);
                return result;
            }
            return reportModel.TotalCountOfEmployee == 0 ? "There's no repot analytics" : result;
        }

    }
}
