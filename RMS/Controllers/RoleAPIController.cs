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
    [Route("api/Role")]
    [ApiController]
    public class RoleAPIController : ControllerBase
    {
        private readonly RoleService _roleService;
        private readonly CobolService _cobolService;
        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];

        public RoleAPIController(RMSContext context)
        {
            _roleService = new RoleService(context);
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAllRoleActive()
        {
            var rbuModel = _roleService.GetAllRole();
            var result = string.Empty;
            if (rbuModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(rbuModel);
                return result;
            }
            return rbuModel.Count() == 0 ? "There's no active Roles" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(RoleCreateViewModel viewModel)
        {
            var roleModel = _roleService.CreateRole(viewModel);
            var result = string.Empty;
            if (roleModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(roleModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE ROLE", cobolAppPath);
                    }
                }
            }
            return roleModel == 0 ? "Roles Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(RoleUpdateViewModel viewModel)
        {
            var roleModel = _roleService.UpdateRole(viewModel);
            var result = string.Empty;
            if (roleModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(roleModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", UPDATE ROLE", cobolAppPath);
                    }
                }
            }
            return roleModel == 0 ? "Role Transaction Failed!" : result;
        }


        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var roleModel = _roleService.DeleteRole(id, UserAccountId);
            var result = string.Empty;
            if (roleModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(roleModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE ROLE", cobolAppPath);
                    }
                }
            }
            return roleModel == 0 ? "Role Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var roleModel = _roleService.RestoreRole(id, UserAccountId);
            var result = string.Empty;
            if (roleModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(roleModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE ROLE", cobolAppPath);
                    }
                }
            }
            return roleModel == 0 ? "Role Transaction Failed!" : result;
        }
        [HttpGet("GetById")]
        public async Task<string> GetById(int id)
        {
            var roleModel = _roleService.GetById(id);
            var result = string.Empty;
            if (roleModel.RoleId != 0)
            {
                result = JsonConvert.SerializeObject(roleModel);
                return result;
            }
            return roleModel.RoleId == 0 ? "Role not found" : result;
        }

    }
}
