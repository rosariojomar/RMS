using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/MNGResource")]
    [ApiController]
    public class MNGResourceAPI : ControllerBase
    {

        private readonly ManageResourceService _mngService;
        public MNGResourceAPI(RMSContext context)
        {
            _mngService = new ManageResourceService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllResourceActive()
        {
            var mngModel = _mngService.GetAllActive();
            var result = string.Empty;
            if (mngModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(mngModel);
                return result;
            }
            return mngModel.Count() == 0 ? "There's no active Resource(s)" : result;
        }

        [HttpPost("CreateResource")]
        public async Task<string> Create(ManageResourceCreateViewModel viewModel)
        {
            var mngModel = _mngService.CreateResource(viewModel);
            var result = string.Empty;
            if (mngModel != 0)
            {
                result = JsonConvert.SerializeObject(mngModel);
                return result;
            }
            return mngModel == 0 ? "Create Resource Transaction Failed!" : result;
        }

        [HttpPost("EditResource")]
        public async Task<string> Update(ManageResourceUpdateViewModel viewModel)
        {
            var mngModel = _mngService.UpdateResource(viewModel);
            var result = string.Empty;
            if (mngModel != 0)
            {
                result = JsonConvert.SerializeObject(mngModel);
                return result;
            }
            return mngModel == 0 ? "Update Resource Transaction Failed!" : result;
        }


        [HttpPost("DeleteRBU")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var mngModel = _mngService.DeleteResource(id, UserAccountId);
            var result = string.Empty;
            if (mngModel != 0)
            {
                result = JsonConvert.SerializeObject(mngModel);
                return result;
            }
            return mngModel == 0 ? "Delete Resource Transaction Failed!" : result;
        }

        [HttpPost("RestoreRBU")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var mngModel = _mngService.RestoreResource(id, UserAccountId);
            var result = string.Empty;
            if (mngModel != 0)
            {
                result = JsonConvert.SerializeObject(mngModel);
                return result;
            }
            return mngModel == 0 ? "Restore Resource Transaction Failed!" : result;
        }


    }
}
