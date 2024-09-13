using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    public class UserAccountAPIController : Controller
    {
        private readonly UserAccountService _userAccountService;
        public UserAccountAPIController(RMSContext context)
        {
            _userAccountService = new UserAccountService(context);
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
                result = JsonConvert.SerializeObject(userAccModel);
                return result;
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
                result = JsonConvert.SerializeObject(userAccModel);
                return result;
            }
            return userAccModel == 0 ? "Create UserAccount Transaction Failed!" : result;
        }

        [HttpPost("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var userAccModel = _userAccountService.DeleteUserAccount(id, UserAccountId);
            var result = string.Empty;
            if (userAccModel != 0)
            {
                result = JsonConvert.SerializeObject(userAccModel);
                return result;
            }
            return userAccModel == 0 ? "Delete UserAccount Transaction Failed!" : result;
        }

        [HttpPost("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var userAccModel = _userAccountService.RestoreUserAccount(id, UserAccountId);
            var result = string.Empty;
            if (userAccModel != 0)
            {
                result = JsonConvert.SerializeObject(userAccModel);
                return result;
            }
            return userAccModel == 0 ? "Restore UserAccount Transaction Failed!" : result;
        }

    }
}
