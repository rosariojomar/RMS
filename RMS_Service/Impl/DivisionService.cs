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
    public class DivisionService : IDivisionService
    {
        private readonly RMSContext _context;
        public DivisionService(RMSContext context)
        {
            _context = context;
        }

        public int CreateDivision(DivisionCreateViewModel x)
        {
            var DivisionModel = new Division()
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
                CreatedByUserId = x.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = x.IsActive,
            };

            _context.Add(DivisionModel);
            _context.SaveChanges();

            return DivisionModel.DivisionId == 0 ? 0 : 1;
        }

        public int UpdateDivision(DivisionUpdateViewModel x)
        {
            var DivisionModel = _context.Divisions.Where(x => x.DivisionId == x.DivisionId).SingleOrDefault();
            DivisionModel.Code = x.Code;
            DivisionModel.Name = x.Name;
            DivisionModel.Description = x.Description;
            DivisionModel.RBUId = x.RBUId;
            DivisionModel.DepartmentId = x.DepartmentId;
            DivisionModel.UpdatedByUserId = x.UpdatedByUserId;
            DivisionModel.DateUpdated = DateTime.Now;
            DivisionModel.IsActive = x.IsActive;

            _context.Update(DivisionModel);
            _context.SaveChanges();

            return DivisionModel.DivisionId == 0 ? 0 : 1;
        }

        public List<DivisionViewModel> GetAllDivisions()
        {
            var DivisionModel = _context.Divisions.Where(x => x.IsActive == true).Select(x => new DivisionViewModel
            {
                DivisionId = x.DivisionId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
            });

            return DivisionModel.ToList();
        }

        public List<DivisionIdNameViewModel> GetAllNameWithId()
        {
            var DivisionModel = _context.Divisions.Where(x => x.IsActive == false).Select(x => new DivisionIdNameViewModel
            {
                Value = x.DivisionId,
                Text = x.Name,
            });

            return DivisionModel.ToList();
        }

        public List<DivisionViewModel> GetAllDivisionsInactive()
        {
            var DivisionModel = _context.Divisions.Where(x => x.IsActive == false).Select(x => new DivisionViewModel
            {
                DivisionId = x.DivisionId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
            });

            return DivisionModel.ToList();
        }

        public int DeleteDivision(int id, int UserAccountId)
        {
            var DivisionModel = _context.Divisions.Where(x => x.DivisionId == id).SingleOrDefault();
            DivisionModel.DeletedByUserId = UserAccountId;
            DivisionModel.DateDeleted = DateTime.Now;
            DivisionModel.IsActive = false;


            _context.Update(DivisionModel);
            _context.SaveChanges();

            return DivisionModel.DivisionId == 0 ? 0 : 1;

        }

        public int RestoreDivision(int id, int UserAccountId)
        {
            var DivisionModel = _context.Divisions.Where(x => x.DivisionId == id).SingleOrDefault();
            DivisionModel.DeletedByUserId = UserAccountId;
            DivisionModel.DateDeleted = DateTime.Now;
            DivisionModel.IsActive = false;


            _context.Update(DivisionModel);
            _context.SaveChanges();

            return DivisionModel.DivisionId == 0 ? 0 : 1;
        }


        public DivisionUpdateViewModel GetById(int Id)
        {
            var DivisionModel = _context.Divisions.Where(x => x.DivisionId == Id).Select(x => new DivisionUpdateViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
                UpdatedByUserId = x.UpdatedByUserId,
                DateUpdated = DateTime.Now,
                IsActive = x.IsActive,
            });

            return (DivisionUpdateViewModel)DivisionModel;
        }
    }

}

