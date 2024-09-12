using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAllUser();
        List<UserViewModel> GetAllUserInactive();

        int CreateUser(UserCreateViewModel rbuVM);
        int UpdateUser(UserUpdateViewModel rbuVM);

        List<UserIdNameViewModel> GetAllUserNameWithId();
        int DeleteUser(int id, int UserAccountId);
        int RestoreUser(int id, int UserAccountId);
        UserUpdateViewModel GetById(int Id);
    }
}
