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
    [Route("api/User")]
    [ApiController]
    public class UserAPIController : Controller
    {
        private readonly UserService _userService;
        private readonly CobolService _cobolService;
        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];


        public UserAPIController(RMSContext context)
        {
            _userService = new UserService(context);
            _cobolService = new CobolService();
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllUserActive()
        {
            var userModel = _userService.GetAllUser();
            var result = string.Empty;
            if (userModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(userModel);
                return result;
            }
            return userModel.Count() == 0 ? "There's no active Users" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(UserCreateViewModel viewModel)
        {
            var userModel = _userService.CreateUser(viewModel);
            var result = string.Empty;
            if (userModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userModel);
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE USER ACCOUNT", cobolAppPath);
                    }
                }
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(UserUpdateViewModel viewModel)
        {
            var userModel = _userService.UpdateUser(viewModel);
            var result = string.Empty;
            if (userModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", UPDATE USER", cobolAppPath);
                    }
                }
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var userModel = _userService.DeleteUser(id, UserAccountId);
            var result = string.Empty;
            if (userModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE USER", cobolAppPath);
                    }
                }
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var userModel = _userService.RestoreUser(id, UserAccountId);
            var result = string.Empty;
            if (userModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(userModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE USER", cobolAppPath);
                    }
                }
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpGet("NameList")]
        public async Task<string> GetRBUNameList()
        {
            var userModel = _userService.GetAllUserNameWithId();
            var result = string.Empty;
            if (userModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(userModel);
                return result;
            }
            return userModel.Count() == 0 ? "There's no active Users" : result;
        }

        [HttpGet("GetById")]
        public async Task<string> GetById(int Id)
        {
            var userModel = _userService.GetById(Id);
            var result = string.Empty;
            if (userModel.UserId != 0)
            {
                result = JsonConvert.SerializeObject(userModel);
                return result;
            }
            return userModel.UserId == 0 ? "User not found" : result;
        }
    }
}
