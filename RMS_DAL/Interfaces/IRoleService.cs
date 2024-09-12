using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IRoleService
    {

        List<RoleViewModel> GetAllRole();
        List<RoleViewModel> GetAllRoleInactive();
        int CreateRole(RoleCreateViewModel userVM);
        int UpdateRole(RoleUpdateViewModel userVM);
        int DeleteRole(int id, int UserAccountId);
        int RestoreRole(int id, int UserAccountId);
        List<RoleIdNameViewModel> GetAllNameWithId();
        RoleUpdateViewModel GetById(int id);
    }
}
