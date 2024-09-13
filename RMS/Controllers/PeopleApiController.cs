using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

namespace RMS.Controllers
{
    [Route("api/People")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly CobolService _cobolService;

        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];

        public PeopleAPIController(RMSContext context)
        {
            _personService = new PersonService(context);
            _cobolService = new CobolService();
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
                try
                {
                    result = JsonConvert.SerializeObject(personModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE PERSON", cobolAppPath);
                    }
                }

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
                try
                {
                    result = JsonConvert.SerializeObject(personModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.UpdatedByUserId.ToString() + ", UPDATE PERSON", cobolAppPath);
                    }
                }
            }
            return personModel == 0 ? "Person Transaction Failed!" : result;
        }

        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var personModel = _personService.DeletePerson(id, UserAccountId);
            var result = string.Empty;
            if (personModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(personModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE PERSON", cobolAppPath);
                    }
                }
            }
            return personModel == 0 ? "Person Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var personModel = _personService.RestorePerson(id, UserAccountId);
            var result = string.Empty;
            if (personModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(personModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE PERSON", cobolAppPath);
                    }
                }


            }
            return personModel == 0 ? "Person Transaction Failed!" : result;
        }

        [HttpGet("GetById")]
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
