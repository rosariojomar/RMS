using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("api/People")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {
        private readonly PersonService _personService;
        public PeopleAPIController(RMSContext context)
        {
            _personService = new PersonService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllPeople()
        {
            var deptModel = _personService.GetAll();
            var result = string.Empty;
            if (deptModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel.Count() == 0 ? "There's no active Departments" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create([FromBody] PersonCreateViewModel viewModel)
        {
            var personModel = _personService.CreatePerson(viewModel);
            var result = string.Empty;
            if (personModel != 0)
            {
                result = JsonConvert.SerializeObject(personModel);
                return result;
            }
            return personModel == 0 ? "Person Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update([FromBody] PersonUpdateViewModel viewModel)
        {
            var personModel = _personService.UpdatePerson(viewModel);
            var result = string.Empty;
            if (personModel != 0)
            {
                result = JsonConvert.SerializeObject(personModel);
                return result;
            }
            return personModel == 0 ? "Person Transaction Failed!" : result;
        }

        [HttpPost("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var personModel = _personService.DeletePerson(id, UserAccountId);
            var result = string.Empty;
            if (personModel != 0)
            {
                result = JsonConvert.SerializeObject(personModel);
                return result;
            }
            return personModel == 0 ? "Person Transaction Failed!" : result;
        }

        [HttpPost("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var personModel = _personService.RestorePerson(id, UserAccountId);
            var result = string.Empty;
            if (personModel != 0)
            {
                result = JsonConvert.SerializeObject(personModel);
                return result;
            }
            return personModel == 0 ? "Person Transaction Failed!" : result;
        }

        [HttpPost("GetById")]
        public async Task<string> GetById(int id)
        {
            var personModel = _personService.GetPersonById(id);
            var result = string.Empty;
            if (personModel.PersonId != 0)
            {
                result = JsonConvert.SerializeObject(personModel);
                return result;
            }
            return personModel.PersonId == 0 ? "Person Transaction Failed!" : result;
        }

    }
}
