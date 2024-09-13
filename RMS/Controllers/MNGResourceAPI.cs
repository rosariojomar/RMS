using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_COBOL.Impl;
using RMS_DAL.Enum;
using RMS_DAL.Interfaces;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/MNGResource")]
    [ApiController]
    public class MNGResourceAPI : ControllerBase
    {

        private readonly ManageResourceService _mngService;
        private readonly CobolService _cobolService;

        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];

        public MNGResourceAPI(RMSContext context)
        {
            _mngService = new ManageResourceService(context);
            _cobolService = new CobolService();
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllResourceActive()
        {
            var mngModel = _mngService.GetAllActive();
            var result = string.Empty;
            if (mngModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(mngModel);
                return result;
            }
            return mngModel.Count() == 0 ? "There's no active Resource(s)" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(ManageResourceCreateViewModel viewModel)
        {
            var mngModel = _mngService.CreateResource(viewModel);
            var result = string.Empty;
            if (mngModel != 0)
            {

                try
                {
                    result = JsonConvert.SerializeObject(mngModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE MANAGE RESOURCE", cobolAppPath);
                    }

                }

            }
            return mngModel == 0 ? "Create Resource Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(ManageResourceUpdateViewModel viewModel)
        {
            var mngModel = _mngService.UpdateResource(viewModel);
            var result = string.Empty;
            if (mngModel != 0)
            {

                try
                {
                    result = JsonConvert.SerializeObject(mngModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", UPDATE MANAGE RESOURCE", cobolAppPath);
                    }

                }
            }
            return mngModel == 0 ? "Update Resource Transaction Failed!" : result;
        }


        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var mngModel = _mngService.DeleteResource(id, UserAccountId);
            var result = string.Empty;
            if (mngModel != 0)
            {
            

                try
                {
                    result = JsonConvert.SerializeObject(mngModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE MANAGE RESOURCE", cobolAppPath);
                    }

                }
            }
            return mngModel == 0 ? "Delete Resource Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var mngModel = _mngService.RestoreResource(id, UserAccountId);
            var result = string.Empty;
            if (mngModel != 0)
            {
                
                try
                {
                    result = JsonConvert.SerializeObject(mngModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE MANAGE RESOURCE", cobolAppPath);
                }
            }
            return mngModel == 0 ? "Restore Resource Transaction Failed!" : result;
        }


        [HttpGet("GetById")]
        public async Task<string> GetById(int id)
        {
            var mngModel = _mngService.GetById(id);
            var result = string.Empty;
            if (mngModel.PersonId != 0)
            {
                result = JsonConvert.SerializeObject(mngModel);
                return result;
            }
            return mngModel.PersonId == 0 ? "Resource not found" : result;
        }


    }
}
