﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_COBOL.Impl;
using RMS_DAL.Enum;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Unit")]
    [ApiController]
    public class UnitAPIController : Controller
    {
        private readonly UnitService _UnitService;
        private readonly CobolService _cobolService;
        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];

        public UnitAPIController(RMSContext context)
        {
            _UnitService = new UnitService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllUnitActive()
        {
            var UnitModel = _UnitService.GetAllUnits();
            var result = string.Empty;
            if (UnitModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel.Count() == 0 ? "There's no active Units" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(UnitCreateViewModel viewModel)
        {
            var UnitModel = _UnitService.CreateUnit(viewModel);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(UnitModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE UNIT", cobolAppPath);
                    }
                }
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(UnitUpdateViewModel viewModel)
        {
            var UnitModel = _UnitService.UpdateUnit(viewModel);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(UnitModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.UpdatedByUserId.ToString() + ", UPDATE UNIT", cobolAppPath);
                    }
                }
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var UnitModel = _UnitService.DeleteUnit(id, UserAccountId);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(UnitModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE UNIT", cobolAppPath);
                    }
                }
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var UnitModel = _UnitService.RestoreUnit(id, UserAccountId);
            var result = string.Empty;
            if (UnitModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(UnitModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE UNIT", cobolAppPath);
                    }
                }
            }
            return UnitModel == 0 ? "Unit Transaction Failed!" : result;
        }

        [HttpGet("NameList")]
        public async Task<string> GetUnitNameList()
        {
            var UnitModel = _UnitService.GetAllNameWithId();
            var result = string.Empty;
            if (UnitModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel.Count() == 0 ? "There's no active Units" : result;
        }

        [HttpGet("GetById")]
        public async Task<string> GetById(int Id)
        {
            var UnitModel = _UnitService.GetById(Id);
            var result = string.Empty;
            if (UnitModel.UnitId != 0)
            {
                result = JsonConvert.SerializeObject(UnitModel);
                return result;
            }
            return UnitModel.UnitId == 0 ? "Unit not found" : result;
        }


    }
}
