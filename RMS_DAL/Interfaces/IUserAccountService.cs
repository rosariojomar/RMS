using Microsoft.EntityFrameworkCore;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IUserAccountService
    {
      
        UserAccountViewModel Login(string username, string password);

        UserAccountModuleViewModel UserModuleAccess(int UserId, int RoleId);

        int CreateUserAccount(UserAccountCreateViewModel vm);
        int UpdateUserAccount(UserAccountUpdateViewModel vm);
        int DeleteUserAccount(UserAccountUpdateViewModel vm);
        int RestoreUserAccount(UserAccountUpdateViewModel vm);


    }
}
