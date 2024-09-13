using Microsoft.EntityFrameworkCore;
using RMS_DAL.Enum;
using RMS_DAL.Interfaces;
using RMS_DAL.Models;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Service.Impl
{
    public class UserAccountService : IUserAccountService
    {
        private readonly RMSContext _context;
        public UserAccountService(RMSContext context)
        {
            _context = context;
        }
      
        public UserAccountViewModel Login(string username, string password)
        {
            var userAccountVMModel = new UserAccountViewModel();

            var userAccountModel = _context.UserAccounts.Where(x => x.Username == username && x.Password == password).SingleOrDefault();

            if (userAccountModel != null)
            {
                var personModel = _context.People.Where(x => x.PersonId == userAccountModel.PersonId).SingleOrDefault();
                userAccountVMModel.UserAccountId = userAccountModel.UserAccountId;
                userAccountVMModel.Username = userAccountModel.Username;
                userAccountVMModel.Role = _context.Roles.Where(x => x.RoleId == userAccountModel.RoleId).SingleOrDefault().Name;
                userAccountVMModel.Fullname = personModel.LastName + ", " + personModel.FirstName;
                userAccountVMModel.RoleId = userAccountModel.RoleId;
                userAccountVMModel.RoleName = _context.Roles.Where(_x => _x.RoleId == userAccountModel.RoleId).SingleOrDefault().Name;
                userAccountVMModel.UserId = userAccountModel.UserId;
                userAccountVMModel.UserType = _context.Users.Where(_x => _x.UserId == userAccountModel.UserId).SingleOrDefault().Name;
            }

            return userAccountVMModel;
        }

        public UserAccountModuleViewModel UserModuleAccess(int UserId, int RoleId)
        {
            var UAMViewModel = new UserAccountModuleViewModel();
            try
            {

                var userAccessModel = _context.UserPolicies.Where(x => x.UserId == UserId && x.RoleId == RoleId).SingleOrDefault();

                if (userAccessModel != null)
                {
                    var userAccessTransactModel = _context.UserPolicyTransactions.Where(x => x.UserPolicyId == userAccessModel.UserPolicyId);

                    UserAccountModuleViewModel listAccessModule = new UserAccountModuleViewModel()
                    {
                        UserModuleAccess = new List<UserModuleViewModel>()
                    };
                    //listAccessModule.UserAccountId = userAccessModel.U

                    foreach (var userModuleAcces in userAccessTransactModel)
                    {
                        UserModuleViewModel userModuleViewModel = new UserModuleViewModel()
                        {
                            ModuleId = userModuleAcces.ModuleId,
                            ModuleDescription = _context.Modules.Where(x => x.ModuleId == userModuleAcces.ModuleId).SingleOrDefault().ModuleDescription.ToString(),
                            ModuleAccess = new List<int>()
                        };

                        if (userModuleAcces.CreateAccess)
                        {
                            userModuleViewModel.ModuleAccess.Add((int)Access.Create);
                        }
                        if (userModuleAcces.UpdateAccess)
                        {
                            userModuleViewModel.ModuleAccess.Add((int)Access.Update);
                        }
                        if (userModuleAcces.ReadAccess)
                        {
                            userModuleViewModel.ModuleAccess.Add((int)Access.Read);
                        }
                        if (userModuleAcces.DeleteAccess)
                        {
                            userModuleViewModel.ModuleAccess.Add((int)Access.Delete);
                        }
                        if (userModuleAcces.RestoreAccess)
                        {
                            userModuleViewModel.ModuleAccess.Add((int)Access.Restore);
                        }

                        listAccessModule.UserModuleAccess.Add(userModuleViewModel);
                    }
                    UAMViewModel = listAccessModule;
                }

                return UAMViewModel;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            return UAMViewModel;

        }

        public List<UserAccountViewModel> GetAllUserAccount()
        {
            var userModel = _context.UserAccounts.Where(x => x.IsActive == true).Select(x => new UserAccountViewModel
            {
                UserAccountId = x.UserAccountId,
                Username = x.Username,
                UserId = x.UserId,
                UserType = _context.Users.Where(x => x.UserId == x.UserId).SingleOrDefault().Name,
                PersonId = x.PersonId,
                Fullname = _context.People.Where(x => x.PersonId == x.PersonId).SingleOrDefault().LastName + ", " + _context.People.Where(x => x.PersonId == x.PersonId).SingleOrDefault().FirstName,
                RoleId = x.RoleId,
                RoleName = _context.Roles.Where(x => x.RoleId == x.RoleId).SingleOrDefault().Name,
                CreatedByUserId = x.CreatedByUserId,
                DateCreated = x.DateCreated,
                IsActive = x.IsActive,
            });

            return userModel.ToList();
        }


        public int CreateUserAccount(UserAccountCreateViewModel vm)
        {
            var userAccModel = new UserAccount()
            {
                Username = vm.Username,
                Password = vm.Password,
                UserId = vm.UserId,
                PersonId = vm.PersonId,
                RoleId = vm.RoleId,
                CreatedByUserId = vm.CreatedByUserId,
                DateCreated = vm.DateCreated,
                IsActive = vm.IsActive,
            };

            _context.Add(userAccModel);
            _context.SaveChanges();
            return userAccModel.UserAccountId == 0 ? 0 : userAccModel.UserAccountId;
        }

        public int UpdateUserAccount(UserAccountUpdateViewModel vm)
        {
            var userAccModel = _context.UserAccounts.Where(x => x.UserAccountId == vm.UserAccountId).SingleOrDefault();
            userAccModel.Username = vm.Username;
            userAccModel.Password = vm.Password;
            userAccModel.UserId = vm.UserId;
            userAccModel.PersonId = vm.PersonId;
            userAccModel.RoleId = vm.RoleId;
            userAccModel.UpdatedByUserId = vm.UpdatedByUserId;
            userAccModel.DateUpdated = DateTime.Now;
            userAccModel.IsActive = vm.IsActive;

            _context.Update(userAccModel);
            _context.SaveChanges();
            return userAccModel.UserAccountId == 0 ? 0 : userAccModel.UserAccountId;
        }

        public int DeleteUserAccount(int Id, int UserAccountId)
        {
            var userAccModel = _context.UserAccounts.Where(x => x.UserAccountId == Id).SingleOrDefault();
            userAccModel.DeletedByUserId = UserAccountId;
            userAccModel.DateDeleted = DateTime.Now;
            userAccModel.IsActive = false;

            _context.Update(userAccModel);
            _context.SaveChanges();
            return userAccModel.UserAccountId == 0 ? 0 : userAccModel.UserAccountId;
        }

        public int RestoreUserAccount(int Id, int UserAccountId)
        {
            var userAccModel = _context.UserAccounts.Where(x => x.UserAccountId == Id).SingleOrDefault();
            userAccModel.RestoredByUserId = UserAccountId;
            userAccModel.DateDeleted = DateTime.Now;
            userAccModel.IsActive = true; 

            _context.Update(userAccModel);
            _context.SaveChanges();
            return userAccModel.UserAccountId == 0 ? 0 : userAccModel.UserAccountId;
        }
    }
}
