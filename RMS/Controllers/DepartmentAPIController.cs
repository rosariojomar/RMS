using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentAPIController : Controller
    {
        private readonly DepartmentService _deptService;

        public DepartmentAPIController(RMSContext context)
        {
            _deptService = new DepartmentService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllRBUActive()
        {
            var deptModel = _deptService.GetAllDept();
            var result = string.Empty;
            if (deptModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel.Count() == 0 ? "There's no active Departments" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create([FromBody]DepartmentCreateViewModel viewModel)
        {
            var deptModel = _deptService.CreateDept(viewModel);
            var result = string.Empty;
            if (deptModel != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel == 0 ? "Department Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(DepartmentUpdateViewModel viewModel)
        {
            var deptModel = _deptService.UpdateDept(viewModel);
            var result = string.Empty;
            if (deptModel != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel == 0 ? "Department Transaction Failed!" : result;
        }

        [HttpPost("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var deptModel = _deptService.DeleteDept(id, UserAccountId);
            var result = string.Empty;
            if (deptModel != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel == 0 ? "Department Transaction Failed!" : result;
        }

        [HttpPost("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var deptModel = _deptService.RestoreDept(id, UserAccountId);
            var result = string.Empty;
            if (deptModel != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel == 0 ? "Department Transaction Failed!" : result;
        }

        [HttpGet("NameList")]
        public async Task<string> GetRBUNameList()
        {
            var deptModel = _deptService.GetAllNameWithId();
            var result = string.Empty;
            if (deptModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel.Count() == 0 ? "There's no active Departments" : result;
        }

        [HttpGet("GetById")]
        public async Task<string> GetById(int id)
        {
            var deptModel = _deptService.GetById(id);
            var result = string.Empty;
            if (deptModel.DepartmentId != 0)
            {
                result = JsonConvert.SerializeObject(deptModel);
                return result;
            }
            return deptModel.DepartmentId == 0 ? "Department not found" : result;
        }
    }
}
