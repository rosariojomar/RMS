using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Policy")]
    [ApiController]
    public class UserPolicyAPIController : Controller
    {
        private readonly PolicyService _policyService;

        public UserPolicyAPIController(RMSContext context)
        {
            _policyService = new PolicyService(context);
        }


        [HttpGet("GetAll")]
        public async Task<string> GetAllTrainingActive()
        {
            var policyModel = _policyService.GetAllActive();
            var result = string.Empty;
            if (policyModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(policyModel);
                return result;
            }
            return policyModel.Count() == 0 ? "There's no active Training(s)" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(PolicyCreateViewModel viewModel)
        {
            var policyModel = _policyService.CreatePolicy(viewModel);
            var result = string.Empty;
            if (policyModel != 0)
            {
                result = JsonConvert.SerializeObject(policyModel);
                return result;
            }
            return policyModel == 0 ? "Create Policy Transaction Failed!" : result;
        }

        [HttpPost("Edit")]
        public async Task<string> Update(PolicyUpdateViewModel viewModel)
        {
            var policyModel = _policyService.UpdatePolicy(viewModel);
            var result = string.Empty;
            if (policyModel != 0)
            {
                result = JsonConvert.SerializeObject(policyModel);
                return result;
            }
            return policyModel == 0 ? "Create Policy Transaction Failed!" : result;
        }

        [HttpPost("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var policyModel = _policyService.DeletePolicy(id, UserAccountId);
            var result = string.Empty;
            if (policyModel != 0)
            {
                result = JsonConvert.SerializeObject(policyModel);
                return result;
            }
            return policyModel == 0 ? "Delete Policy Transaction Failed!" : result;
        }

        [HttpPost("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var policyModel = _policyService.RestorePolicy(id, UserAccountId);
            var result = string.Empty;
            if (policyModel != 0)
            {
                result = JsonConvert.SerializeObject(policyModel);
                return result;
            }
            return policyModel == 0 ? "Delete Policy Transaction Failed!" : result;
        }

    }
}
