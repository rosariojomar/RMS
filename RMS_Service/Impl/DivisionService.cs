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
    public class DivisionService
    {
        private readonly RMSContext _context;
        public DivisionService(RMSContext context)
        {
            _context = context;
        }

        public int CreateDivision(DivisionCreateViewModel DivisionVM)
        {
            var DivisionModel = new Division()
            {
                Code = DivisionVM.Code,
                Name = DivisionVM.Name,
                Description = DivisionVM.Description,
                RBUId = DivisionVM.RBUId,
                DepartmentId = DivisionVM.DepartmentId,
                CreatedByUserId = DivisionVM.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = DivisionVM.IsActive,
            };

            _context.Add(DivisionModel);
            _context.SaveChanges();

            return DivisionModel.DivisionId == 0 ? 0 : 1;
        }

        public int UpdateDivision(DivisionUpdateViewModel DivisionVM)
        {
            var DivisionModel = _context.Divisions.Where(x => x.DivisionId == DivisionVM.DivisionId).SingleOrDefault();
            DivisionModel.Code = DivisionVM.Code;
            DivisionModel.Name = DivisionVM.Name;
            DivisionModel.Description = DivisionVM.Description;
            DivisionModel.RBUId = DivisionVM.RBUId;
            DivisionModel.DepartmentId = DivisionVM.DepartmentId;
            DivisionModel.UpdatedByUserId = DivisionVM.UpdatedByUserId;
            DivisionModel.DateUpdated = DateTime.Now;
            DivisionModel.IsActive = DivisionVM.IsActive;

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
    }

}
}
