﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/RBU")]
    [ApiController]
    public class RBUAPIController : Controller
    {
        private readonly RBUService _rbuService;

        public RBUAPIController(RMSContext context)
        {
            _rbuService = new RBUService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllRBUActive()
        {
            var rbuModel = _rbuService.GetAllRbus();
            var result = string.Empty;
            if (rbuModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return  rbuModel.Count() == 0 ? "There's no active RBUs" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(RBUCreateViewModel viewModel)
        {
            var rbuModel = _rbuService.CreateRBU(viewModel);
            var result = string.Empty;
            if (rbuModel != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return rbuModel == 0 ? "RBU Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(RBUUpdateViewModel viewModel)
        {
            var rbuModel = _rbuService.UpdateRBU(viewModel);
            var result = string.Empty;
            if (rbuModel != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return rbuModel == 0 ? "RBU Transaction Failed!" : result;
        }

        [HttpPost("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var rbuModel = _rbuService.DeleteRBU(id, UserAccountId);
            var result = string.Empty;
            if (rbuModel != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return rbuModel == 0 ? "RBU Transaction Failed!" : result;
        }

        [HttpPost("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var rbuModel = _rbuService.RestoreRBU(id, UserAccountId);
            var result = string.Empty;
            if (rbuModel != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return rbuModel == 0 ? "RBU Transaction Failed!" : result;
        }

        [HttpGet("NameList")]
        public async Task<string> GetRBUNameList()
        {
            var rbuModel = _rbuService.GetAllNameWithId();
            var result = string.Empty;
            if (rbuModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return rbuModel.Count() == 0 ? "There's no active RBUs" : result;
        }

        [HttpGet("GetById")]
        public async Task<string> GetById(int Id)
        {
            var rbuModel = _rbuService.GetById(Id);
            var result = string.Empty;
            if (rbuModel.RBUId != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return rbuModel.RBUId == 0 ? "There's no active RBUs" : result;
        }

    }
}
