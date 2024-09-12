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
    public class DepartmentService : IDepartmentService
    {
        private readonly RMSContext _context;
        public DepartmentService(RMSContext context)
        {
            _context = context;
        }

        public int CreateDept(DepartmentCreateViewModel userVM)
        {
            var deptModel = new Department()
            {
                Code = userVM.Code,
                Name = userVM.Name,
                Description = userVM.Description,
                CreatedByUserId = userVM.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = userVM.IsActive,
                RBUId = userVM.RBUId,
            };

            _context.Add(deptModel);
             _context.SaveChanges();
            var newDeptId = deptModel.DepartmentId;
            return newDeptId == 0 ? 0 : 1;
        }
        public int DeleteDept(int id, int UserAccountId)
        {
            var deptModel = _context.Departments.Where(x => x.DepartmentId == id).SingleOrDefault();
            deptModel.DeletedByUserId = UserAccountId;
            deptModel.DateDeleted = DateTime.Now;
            deptModel.IsActive = false;


            _context.Update(deptModel);
            _context.SaveChanges();

            return deptModel.DepartmentId == 0 ? 0 : 1;
        }

        public List<DepartmentViewModel> GetAllDept()
        {
            var deptModel = _context.Departments.Where(x => x.IsActive == true).Select(x => new DepartmentViewModel
            {
                DepartmentId = x.DepartmentId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
            });

            return deptModel.ToList();
        }

        public List<DepartmentViewModel> GetAllDeptInactive()
        {
            var deptModel = _context.Departments.Where(x => x.IsActive == false).Select(x => new DepartmentViewModel
            {
                DepartmentId = x.DepartmentId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
            });

            return deptModel.ToList();
        }

        public List<DepartmentIdNameViewModel> GetAllNameWithId()
        {
            var deptModel = _context.Departments.Where(x => x.IsActive == true).Select(x => new DepartmentIdNameViewModel
            {
                Value = x.DepartmentId,
                Text = x.Name,
            });

            return deptModel.ToList();
        }

        public int RestoreDept(int id, int UserAccountId)
        {
            var deptModel = _context.Departments.Where(x => x.DepartmentId == id).SingleOrDefault();
            deptModel.DeletedByUserId = UserAccountId;
            deptModel.DateDeleted = DateTime.Now;
            deptModel.IsActive = true;


            _context.Update(deptModel);
            _context.SaveChanges();

            return deptModel.DepartmentId == 0 ? 0 : 1;
        }

        public int UpdateDept(DepartmentUpdateViewModel userVM)
        {
            var deptModel = _context.Departments.Where(x => x.DepartmentId == userVM.DepartmentId).SingleOrDefault();
            deptModel.Code = userVM.Code;
            deptModel.Name = userVM.Name;
            deptModel.Description = userVM.Description;
            deptModel.RBUId = userVM.RBUId;
            deptModel.UpdatedByUserId = userVM.UpdatedByUserId;
            deptModel.DateUpdated = DateTime.Now;
            deptModel.IsActive = userVM.IsActive;

            _context.Update(deptModel);
            _context.SaveChanges();

            return deptModel.DepartmentId == 0 ? 0 : 1;
        }

        public DepartmentViewModel GetById(int Id)
        {
            var deptModel = _context.Departments.Where(x => x.IsActive == true && x.DepartmentId == Id).Select(x => new DepartmentViewModel
            {
                DepartmentId = x.DepartmentId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
            });

            return (DepartmentViewModel)deptModel;
        }
    }
}
