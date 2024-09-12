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
    public class RoleService : IRoleService
    {
        private readonly RMSContext _context;
        public RoleService(RMSContext context)
        {
            _context = context;
        }
        public int CreateRole(RoleCreateViewModel userVM)
        {
            var roleModel = new Role()
            {
                Code = userVM.Code,
                Name = userVM.Name,
                Description = userVM.Description,
                CreatedByUserId = userVM.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = userVM.IsActive,
            };

            _context.Add(roleModel);
            _context.SaveChanges();

            return roleModel.RoleId == 0 ? 0 : 1;
        }

        public int UpdateRole(RoleUpdateViewModel userVM)
        {
            var roleModel = _context.Roles.Where(x => x.RoleId == userVM.RoleId).SingleOrDefault();
            roleModel.Code = userVM.Code;
            roleModel.Name = userVM.Name;
            roleModel.Description = userVM.Description;
            roleModel.UpdatedByUserId = userVM.UpdatedByUserId;
            roleModel.DateUpdated = DateTime.Now;
            roleModel.IsActive = userVM.IsActive;

            _context.Update(roleModel);
            _context.SaveChanges();

            return roleModel.RoleId == 0 ? 0 : 1;
        }

        public int DeleteRole(int id, int UserAccountId)
        {
            var roleModel = _context.Roles.Where(x => x.RoleId == id).SingleOrDefault();
            roleModel.DeletedByUserId = UserAccountId;
            roleModel.DateDeleted = DateTime.Now;
            roleModel.IsActive = false;


            _context.Update(roleModel);
            _context.SaveChanges();

            return roleModel.RoleId == 0 ? 0 : 1;
        }

        public int RestoreRole(int id, int UserAccountId)
        {
            var roleModel = _context.Roles.Where(x => x.RoleId == id).SingleOrDefault();
            roleModel.DeletedByUserId = UserAccountId;
            roleModel.DateDeleted = DateTime.Now;
            roleModel.IsActive = true;


            _context.Update(roleModel);
            _context.SaveChanges();

            return roleModel.RoleId == 0 ? 0 : 1;
        }

        public List<RoleIdNameViewModel> GetAllNameWithId()
        {
            var roleModel = _context.Roles.Where(x => x.IsActive == true).Select(x => new RoleIdNameViewModel
            {
                Value = x.RoleId,
                Text = x.Name,
            });

            return roleModel.ToList();
        }

        public List<RoleViewModel> GetAllRole()
        {
            var roleModel = _context.Roles.Where(x => x.IsActive == true).Select(x => new RoleViewModel
            {
                RoleId = x.RoleId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
            });

            return roleModel.ToList();
        }

        public List<RoleViewModel> GetAllRoleInactive()
        {
            var roleModel = _context.Roles.Where(x => x.IsActive == false).Select(x => new RoleViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
            });

            return roleModel.ToList();
        }

        public RoleUpdateViewModel GetById(int id)
        {
            var roleModel = _context.Roles.Where(x => x.RoleId == id).Select(x => new RoleUpdateViewModel {
                RoleId = x.RoleId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                UpdatedByUserId = x.UpdatedByUserId,
                DateUpdated = DateTime.Now,
                IsActive = x.IsActive,
            });

            return (RoleUpdateViewModel)roleModel;
        }
    }
}
