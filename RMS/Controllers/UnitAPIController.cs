using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Unit")]
    [ApiController]
    public class UnitAPIController : Controller
    {
        private readonly UnitService _UnitService;

        public UnitAPIController(RMSContext context)
        {
            _UnitService = new UnitService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllUnitActive()
        {
            var UnitModel = _UnitService.GetAllUnits();
            var result = string.Empty;
            if (UnitModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel.Count() == 0 ? "There's no active Units" : result;
        }

        [HttpPost("CreateUnit")]
        public async Task<string> Create(UnitCreateViewModel viewModel)
        {
            var UnitModel = _UnitService.CreateUnit(viewModel);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpPost("UpdateUnit")]
        public async Task<string> Update(UnitUpdateViewModel viewModel)
        {
            var UnitModel = _UnitService.UpdateUnit(viewModel);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpPost("DeleteUnit")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var UnitModel = _UnitService.DeleteUnit(id, UserAccountId);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpPost("RestoreUnit")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var UnitModel = _UnitService.RestoreUnit(id, UserAccountId);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpGet("UnitNameList")]
        public async Task<string> GetUnitNameList()
        {
            var UnitModel = _UnitService.GetAllNameWithId();
            var result = string.Empty;
            if (UnitModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel.Count() == 0 ? "There's no active Units" : result;
        }

    }
}
