using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RMS_DAL.Models;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        private readonly RMSContext _context;
        private readonly UserAccountService _userAccountService;

        public LoginAPIController(RMSContext context)
        {
            _context = context;
            _userAccountService = new UserAccountService(context);
        }

        // GET: api/PeopleAPI
        [HttpGet("UserLogin")]
        public async Task<string> UserLogin(string username, string password)
        {
            var userAccModel = _userAccountService.Login(username, password);

            if (userAccModel != null)
            {
                var result = JsonConvert.SerializeObject(userAccModel);
                return result;
            }
            return "User or Password is Invalid";
        }

        // GET: api/PeopleAPI
        [Route("Login/All")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

    }
}
