using Microsoft.EntityFrameworkCore;
using RMS_DAL.Interfaces;
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

            if (userAccountVMModel != null)
            {
                var personModel = _context.People.Where(x => x.PersonId == x.PersonId).SingleOrDefault();
                userAccountVMModel.UserAccountId = userAccountModel.UserAccountId;
                userAccountVMModel.Username = userAccountModel.Username;
                userAccountVMModel.Role = _context.Roles.Where(x => x.RoleId == userAccountModel.RoleId).SingleOrDefault().Name;
                userAccountVMModel.Fullname = personModel.FirstName + " " + personModel.LastName;
            }

            return userAccountVMModel;
        }






    }
}
