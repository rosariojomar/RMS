using Microsoft.EntityFrameworkCore;
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
    public class UserService : IUserService
    {
        private readonly RMSContext _context;
        public UserService(RMSContext context)
        {
            _context = context;
        }
        public int CreateUser(UserCreateViewModel userVM)
        {
            var userModel = new User()
            {
                Code = userVM.Code,
                Name = userVM.Name,
                Description = userVM.Description,
                CreatedByUserId = userVM.CreatedByUserId,
                DateCreated = userVM.DateCreated,
                IsActive = userVM.IsActive,
            };

            _context.Add(userModel);
            _context.SaveChangesAsync();

            return userModel.UserId == 0 ? 0 : 1;
        }
        public int UpdateUser(UserUpdateViewModel userVM)
        {
            var userModel = new User()
            {
                Code = userVM.Code,
                Name = userVM.Name,
                Description = userVM.Description,
                UpdatedByUserId = userVM.CreatedByUserId,
                DateUpdated = userVM.DateUpdated,
                IsActive = userVM.IsActive,
            };

            _context.Add(userModel);
            _context.SaveChangesAsync();

            return userModel.UserId == 0 ? 0 : 1;
        }

        public List<UserViewModel> GetAllUser()
        {
            var userModel = _context.Users.Where(x => x.IsActive == true).Select(x => new UserViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
            });

            return userModel.ToList();
        }

        public List<UserViewModel> GetAllUserInactive()
        {
            var userModel = _context.Users.Where(x => x.IsActive == false).Select(x => new UserViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
            });

            return userModel.ToList();
        }

        public List<UserIdNameViewModel> GetAllUserNameWithId()
        {
            var userModel = _context.Users.Where(x => x.IsActive == false).Select(x => new UserIdNameViewModel
            {
                Value = x.UserId,
                Text = x.Name,
            });

            return userModel.ToList();
        }

        public int DeleteUser(int id, int UserAccountId)
        {
            var rbuModel = _context.Users.Where(x => x.UserId == id).SingleOrDefault();
            rbuModel.DeletedByUserId = UserAccountId;
            rbuModel.DateDeleted = DateTime.Now;
            rbuModel.IsActive = false;


            _context.Update(rbuModel);
            _context.SaveChangesAsync();

            return rbuModel.UserId == 0 ? 0 : 1;
        }

        public int RestoreUser(int id, int UserAccountId)
        {
            var rbuModel = _context.Users.Where(x => x.UserId == id).SingleOrDefault();
            rbuModel.DeletedByUserId = UserAccountId;
            rbuModel.DateDeleted = DateTime.Now;
            rbuModel.IsActive = false;


            _context.Update(rbuModel);
            _context.SaveChangesAsync();

            return rbuModel.UserId == 0 ? 0 : 1;
        }
    }
}
