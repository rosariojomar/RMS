using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/ReferenceTable")]
    [ApiController]
    public class ReferenceTableAPIController : Controller
    {
        private readonly ReferenceTableService _ReferenceTableService;

        public ReferenceTableAPIController(RMSContext context)
        {
            _ReferenceTableService = new ReferenceTableService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllReferenceTableActive()
        {
            var ReferenceTableModel = _ReferenceTableService.GetAllReferenceTables();
            var result = string.Empty;
            if (ReferenceTableModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(ReferenceTableModel);
                return result;
            }
            return  ReferenceTableModel.Count() == 0 ? "There's no active Reference Tables" : result;
        }

        [HttpPost("CreateReferenceTable")]
        public async Task<string> Create(ReferenceTableCreateViewModel viewModel)
        {
            var ReferenceTableModel = _ReferenceTableService.CreateReferenceTable(viewModel);
            var result = string.Empty;
            if (ReferenceTableModel != 0)
            {
                result = JsonConvert.SerializeObject(ReferenceTableModel);
                return result;
            }
            return ReferenceTableModel == 0 ? "Reference Table Transaction Failed!" : result;
        }

        [HttpPost("UpdateReferenceTable")]
        public async Task<string> Update(ReferenceTableUpdateViewModel viewModel)
        {
            var ReferenceTableModel = _ReferenceTableService.UpdateReferenceTable(viewModel);
            var result = string.Empty;
            if (ReferenceTableModel != 0)
            {
                result = JsonConvert.SerializeObject(ReferenceTableModel);
                return result;
            }
            return ReferenceTableModel == 0 ? "Reference Table Transaction Failed!" : result;
        }

        [HttpPost("DeleteReferenceTable")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var ReferenceTableModel = _ReferenceTableService.DeleteReferenceTable(id, UserAccountId);
            var result = string.Empty;
            if (ReferenceTableModel != 0)
            {
                result = JsonConvert.SerializeObject(ReferenceTableModel);
                return result;
            }
            return ReferenceTableModel == 0 ? "Reference Table Transaction Failed!" : result;
        }

        [HttpPost("RestoreReferenceTable")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var ReferenceTableModel = _ReferenceTableService.RestoreReferenceTable(id, UserAccountId);
            var result = string.Empty;
            if (ReferenceTableModel != 0)
            {
                result = JsonConvert.SerializeObject(ReferenceTableModel);
                return result;
            }
            return ReferenceTableModel == 0 ? "Reference Table Transaction Failed!" : result;
        }

        [HttpGet("ReferenceTableNameList")]
        public async Task<string> GetReferenceTableNameList()
        {
            var ReferenceTableModel = _ReferenceTableService.GetAllNameWithId();
            var result = string.Empty;
            if (ReferenceTableModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(ReferenceTableModel);
                return result;
            }
            return ReferenceTableModel.Count() == 0 ? "There's no active Reference Tables" : result;
        }

    }
}
