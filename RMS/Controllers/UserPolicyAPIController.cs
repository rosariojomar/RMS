using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_COBOL.Impl;
using RMS_DAL.Enum;
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
        private readonly CobolService _cobolService;
        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];
        public UserPolicyAPIController(RMSContext context)
        {
            _policyService = new PolicyService(context);
            _cobolService = new CobolService();
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
            
                try
                {
                    result = JsonConvert.SerializeObject(policyModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally{
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE USER POLICY", cobolAppPath);
                    }
                }
            }
            return policyModel == 0 ? "Create Policy Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(PolicyUpdateViewModel viewModel)
        {
            var policyModel = _policyService.UpdatePolicy(viewModel);
            var result = string.Empty;
            if (policyModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(policyModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", UPDATE USER POLICY", cobolAppPath);
                    }
                }

            }
            return policyModel == 0 ? "Create Policy Transaction Failed!" : result;
        }

        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var policyModel = _policyService.DeletePolicy(id, UserAccountId);
            var result = string.Empty;
            if (policyModel != 0)
            {
              
                try
                {
                    result = JsonConvert.SerializeObject(policyModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE USER POLICY", cobolAppPath);
                    }
                }
            }
            return policyModel == 0 ? "Delete Policy Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var policyModel = _policyService.RestorePolicy(id, UserAccountId);
            var result = string.Empty;
            if (policyModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(policyModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", Restore USER POLICY", cobolAppPath);
                    }
                }
            }
            return policyModel == 0 ? "Delete Policy Transaction Failed!" : result;
        }


        [HttpGet("GetById")]
        public async Task<string> GetById(int Id)
        {
            var policyModel = _policyService.GetById(Id);
            var result = string.Empty;
            if (policyModel.UserPolicyId != 0)
            {
                result = JsonConvert.SerializeObject(policyModel);
                return result;
            }
            return policyModel.UserPolicyId == 0 ? "Policy not found" : result;
        }
    }
}
