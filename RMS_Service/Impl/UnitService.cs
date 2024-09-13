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
    public class UnitService : IUnitService
    {
        private readonly RMSContext _context;
        public UnitService(RMSContext context)
        {
            _context = context;
        }

        public int CreateUnit(UnitCreateViewModel UnitVM)
        {
            var UnitModel = new Unit()
            {
                Code = UnitVM.Code,
                Name = UnitVM.Name,
                Description = UnitVM.Description,
                RBUId = UnitVM.RBUId,
                DepartmentId = UnitVM.DepartmentId,
                DivisionId = UnitVM.DivisionId,
                CreatedByUserId = UnitVM.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = UnitVM.IsActive,
            };

            _context.Add(UnitModel);
            _context.SaveChanges();

            return UnitModel.UnitId == 0 ? 0 : 1;
        }

        public int UpdateUnit(UnitUpdateViewModel UnitVM)
        {
            var UnitModel = _context.Units.Where(x => x.UnitId == UnitVM.UnitId).SingleOrDefault();
            UnitModel.Code = UnitVM.Code;
            UnitModel.Name = UnitVM.Name;
            UnitModel.Description = UnitVM.Description;
            UnitModel.RBUId = UnitVM.RBUId;
            UnitModel.DepartmentId = UnitVM.DepartmentId;
            UnitModel.DivisionId = UnitVM.DivisionId;
            UnitModel.UpdatedByUserId = UnitVM.UpdatedByUserId;
            UnitModel.DateUpdated = DateTime.Now;
            UnitModel.IsActive = UnitVM.IsActive;

            _context.Update(UnitModel);
            _context.SaveChanges();

            return UnitModel.UnitId == 0 ? 0 : 1;
        }

        public List<UnitViewModel> GetAllUnits()
        {
            var UnitModel = _context.Units.Where(x => x.IsActive == true).Select(x => new UnitViewModel
            {
                UnitId = x.UnitId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
                DivisionId = x.DivisionId,
            });

            return UnitModel.ToList();
        }

        public List<UnitIdNameViewModel> GetAllNameWithId()
        {
            var UnitModel = _context.Units.Where(x => x.IsActive == true).Select(x => new UnitIdNameViewModel
            {
                Value = x.UnitId,
                Text = x.Name,
            });

            return UnitModel.ToList();
        }

        public List<UnitViewModel> GetAllUnitsInactive()
        {
            var UnitModel = _context.Units.Where(x => x.IsActive == false).Select(x => new UnitViewModel
            {
                UnitId = x.UnitId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
                DivisionId = x.DivisionId,
            });

            return UnitModel.ToList();
        }

        public int DeleteUnit(int id, int UserAccountId)
        {
            var UnitModel = _context.Units.Where(x => x.UnitId == id).SingleOrDefault();
            UnitModel.DeletedByUserId = UserAccountId;
            UnitModel.DateDeleted = DateTime.Now;
            UnitModel.IsActive = false;


            _context.Update(UnitModel);
            _context.SaveChanges();

            return UnitModel.UnitId == 0 ? 0 : 1;

        }

        public int RestoreUnit(int id, int UserAccountId)
        {
            var UnitModel = _context.Units.Where(x => x.UnitId == id).SingleOrDefault();
            UnitModel.DeletedByUserId = UserAccountId;
            UnitModel.DateDeleted = DateTime.Now;
            UnitModel.IsActive = false;


            _context.Update(UnitModel);
            _context.SaveChanges();

            return UnitModel.UnitId == 0 ? 0 : 1;
        }


        public UnitUpdateViewModel GetById(int Id)
        {
            var UnitModel = _context.Units.Where(x => x.UnitId == Id).Select(x => new UnitUpdateViewModel
            {
                UnitId = x.UnitId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
                DivisionId = x.DivisionId,
                UpdatedByUserId = x.UpdatedByUserId,
                DateUpdated = DateTime.Now,
                IsActive = x.IsActive,
            });

            return (UnitUpdateViewModel)UnitModel;
        }
    }
}
