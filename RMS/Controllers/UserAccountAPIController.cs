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
    [Route("api/UserAccount")]
    [ApiController]
    public class UserAccountAPIController : Controller
    {
        private readonly UserAccountService _userAccountService;
        private readonly CobolService _cobolService;
        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];

        public UserAccountAPIController(RMSContext context)
        {
            _userAccountService = new UserAccountService(context);
            _cobolService = new CobolService();
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAll()
        {
            var userAccModel = _userAccountService.GetAllUserAccount();
            var result = string.Empty;
            if (userAccModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(userAccModel);
                return result;
            }
            return userAccModel.Count() == 0 ? "There's no active UserAccount(s)" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(UserAccountCreateViewModel viewModel)
        {
            var userAccModel = _userAccountService.CreateUserAccount(viewModel);
            var result = string.Empty;
            if (userAccModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userAccModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE USER ACCOUNT", cobolAppPath);
                    }
                }
            }
            return userAccModel == 0 ? "Create UserAccount Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(UserAccountUpdateViewModel viewModel)
        {
            var userAccModel = _userAccountService.UpdateUserAccount(viewModel);
            var result = string.Empty;
            if (userAccModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userAccModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.UpdatedByUserId.ToString() + ", UPDATE USER ACCOUNT", cobolAppPath);
                    }
                }
            }
            return userAccModel == 0 ? "Create UserAccount Transaction Failed!" : result;
        }

        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var userAccModel = _userAccountService.DeleteUserAccount(id, UserAccountId);
            var result = string.Empty;
            if (userAccModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userAccModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE USER ACCOUNT", cobolAppPath);
                    }
                }
            }
            return userAccModel == 0 ? "Delete UserAccount Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var userAccModel = _userAccountService.RestoreUserAccount(id, UserAccountId);
            var result = string.Empty;
            if (userAccModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userAccModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE USER ACCOUNT", cobolAppPath);
                    }
                }
            }
            return userAccModel == 0 ? "Restore UserAccount Transaction Failed!" : result;
        }

    }
}
