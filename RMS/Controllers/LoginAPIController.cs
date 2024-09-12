using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RMS_COBOL.Impl;
using RMS_DAL.Enum;
using RMS_DAL.Models;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;
using RMS.AppSett;

namespace RMS.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        private readonly RMSContext _context;
        private readonly UserAccountService _userAccountService;
        private readonly CobolService _cobolService;

        public LoginAPIController(RMSContext context)
        {
            _context = context;
            _userAccountService = new UserAccountService(context);
            _cobolService = new CobolService();
        }

        // GET: api/PeopleAPI
        [HttpGet("UserLogin")]
        public async Task<string> UserLogin(string username, string password)
        {
            var userAccModel = _userAccountService.Login(username, password);
            var result = string.Empty;
            if (userAccModel.UserAccountId != 0)
            {
                string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
                var logPath = string.Empty;

                result = JsonConvert.SerializeObject(userAccModel);
                _cobolService.WriteLog((int)Cobol.TRANSLOG, username + ", LOGIN", cobolAppPath);
                return result;
            }
            return userAccModel.UserAccountId == 0 ? "User or Password is Invalid" : result;
        }

        // GET: api/PeopleAPI
        [Route("Login/All")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        [HttpGet("UserPolicy")]
        public async Task<string> GetUserPolicy(int userId, int roleId)
        {
            var userAccModel = _userAccountService.UserModuleAccess(userId, roleId);

            if (userAccModel.UserModuleAccess != null)
            {
                var result = JsonConvert.SerializeObject(userAccModel);
                return result;
            }
            
            return "User doesn't have user access policy.";
        }



    }
}
