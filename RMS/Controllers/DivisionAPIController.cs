using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_COBOL.Impl;
using RMS_DAL.Enum;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Division")]
    [ApiController]
    public class DivisionAPIController : Controller
    {
        private readonly DivisionService _DivisionService;
        private readonly CobolService _cobolService;
        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];


        public DivisionAPIController(RMSContext context)
        {
            _DivisionService = new DivisionService(context);
            _cobolService = new CobolService();
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllDivisionActive()
        {
            var DivisionModel = _DivisionService.GetAllDivisions();
            var result = string.Empty;
            if (DivisionModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel.Count() == 0 ? "There's no active Divisions" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(DivisionCreateViewModel viewModel)
        {
            var DivisionModel = _DivisionService.CreateDivision(viewModel);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(DivisionModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond != "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE DIVISION", cobolAppPath);

                    }
                }
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(DivisionUpdateViewModel viewModel)
        {
            var DivisionModel = _DivisionService.UpdateDivision(viewModel);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(DivisionModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond != "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.UpdatedByUserId.ToString() + ", UPDATE DIVISION", cobolAppPath);

                    }
                }
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var DivisionModel = _DivisionService.DeleteDivision(id, UserAccountId);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(DivisionModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond != "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE DIVISION", cobolAppPath);

                    }
                }
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var DivisionModel = _DivisionService.RestoreDivision(id, UserAccountId);
            var result = string.Empty;
            if (DivisionModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(DivisionModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE DIVISION", cobolAppPath);
                }
            }
            return DivisionModel == 0 ? "Division Transaction Failed!" : result;
        }

        [HttpGet("NameList")]
        public async Task<string> GetDivisionNameList()
        {
            var DivisionModel = _DivisionService.GetAllNameWithId();
            var result = string.Empty;
            if (DivisionModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel.Count() == 0 ? "There's no active Divisions" : result;
        }

        [HttpGet("GetById")]
        public async Task<string> GetById(int Id)
        {
            var DivisionModel = _DivisionService.GetById(Id);
            var result = string.Empty;
            if (DivisionModel.DivisionId != 0)
            {
                result = JsonConvert.SerializeObject(DivisionModel);
                return result;
            }
            return DivisionModel.DivisionId == 0 ? "Division not found" : result;
        }



    }
}
