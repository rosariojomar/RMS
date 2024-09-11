using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Division")]
    [ApiController]
    public class DivisionAPIController : Controller
    {
        private readonly DivisionService _DivisionService;

        public DivisionAPIController(RMSContext context)
        {
            _DivisionService = new DivisionService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllDivisionActive()
        {
            var DivisionModel = _DivisionService.GetAllDivisions();
            var result = string.Empty;
            if (DivisionModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel.Count() == 0 ? "There's no active Divisions" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(DivisionCreateViewModel viewModel)
        {
            var DivisionModel = _DivisionService.CreateDivision(viewModel);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(DivisionUpdateViewModel viewModel)
        {
            var DivisionModel = _DivisionService.UpdateDivision(viewModel);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpPost("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var DivisionModel = _DivisionService.DeleteDivision(id, UserAccountId);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpPost("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var DivisionModel = _DivisionService.RestoreDivision(id, UserAccountId);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpGet("NameList")]
        public async Task<string> GetDivisionNameList()
        {
            var DivisionModel = _DivisionService.GetAllNameWithId();
            var result = string.Empty;
            if (DivisionModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel.Count() == 0 ? "There's no active Divisions" : result;
        }

    }
}
