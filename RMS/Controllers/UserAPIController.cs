using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly RMSContext _context;
        private readonly UserService _userService;

        public UserAPIController(RMSContext context)
        {
            _context = context;
            _userService = new UserService(context);
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

        [HttpPost("CreateUser")]
        public async Task<string> Create(UserCreateViewModel viewModel)
        {
            var userModel = _userService.CreateUser(viewModel);
            var result = string.Empty;
            if (userModel != 0)
            {
                result = JsonConvert.SerializeObject(userModel);
                return result;
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpPost("UpdateRBU")]
        public async Task<string> Update(UserUpdateViewModel viewModel)
        {
            var userModel = _userService.UpdateUser(viewModel);
            var result = string.Empty;
            if (userModel != 0)
            {
                result = JsonConvert.SerializeObject(userModel);
                return result;
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpPost("DeleteRBU")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var userModel = _userService.DeleteUser(id, UserAccountId);
            var result = string.Empty;
            if (userModel != 0)
            {
                result = JsonConvert.SerializeObject(userModel);
                return result;
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpPost("RestoreRBU")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var userModel = _userService.RestoreUser(id, UserAccountId);
            var result = string.Empty;
            if (userModel != 0)
            {
                result = JsonConvert.SerializeObject(userModel);
                return result;
            }
            return userModel == 0 ? "User Transaction Failed!" : result;
        }

        [HttpGet("RBUNameList")]
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
    }
}
