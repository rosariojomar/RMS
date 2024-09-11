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
    public class ReferenceTableService : IReferenceTableService
    {
        private readonly RMSContext _context;
        public ReferenceTableService(RMSContext context)
        {
            _context = context;
        }

        public int CreateReferenceTable(ReferenceTableCreateViewModel ReferenceTableVM)
        {
            var ReferenceTableModel = new ReferenceTable()
            {
                Code = ReferenceTableVM.Code,
                Name = ReferenceTableVM.Name,
                Description = ReferenceTableVM.Description,
                Classification = ReferenceTableVM.Classification,
                CreatedByUserId = ReferenceTableVM.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = ReferenceTableVM.IsActive,
            };

            _context.Add(ReferenceTableModel);
            _context.SaveChanges();

            return ReferenceTableModel.ReferenceTableId == 0 ? 0 : 1;
        }

        public int UpdateReferenceTable(ReferenceTableUpdateViewModel ReferenceTableVM)
        {
            var ReferenceTableModel = _context.ReferenceTables.Where(x => x.ReferenceTableId == ReferenceTableVM.ReferenceTableId).SingleOrDefault();
            ReferenceTableModel.Code = ReferenceTableVM.Code;
            ReferenceTableModel.Name = ReferenceTableVM.Name;
            ReferenceTableModel.Description = ReferenceTableVM.Description;
            ReferenceTableModel.Classification = ReferenceTableVM.Classification;
            ReferenceTableModel.UpdatedByUserId = ReferenceTableVM.UpdatedByUserId;
            ReferenceTableModel.DateUpdated = DateTime.Now;
            ReferenceTableModel.IsActive = ReferenceTableVM.IsActive;

            _context.Update(ReferenceTableModel);
            _context.SaveChanges();

            return ReferenceTableModel.ReferenceTableId == 0 ? 0 : 1;
        }

        public List<ReferenceTableViewModel> GetAllReferenceTables()
        {
            var ReferenceTableModel = _context.ReferenceTables.Where(x => x.IsActive == true).Select(x => new ReferenceTableViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                Classification = x.Classification,
            });

            return ReferenceTableModel.ToList();
        }

        public List<ReferenceTableIdNameViewModel> GetAllNameWithId()
        {
            var ReferenceTableModel = _context.ReferenceTables.Where(x => x.IsActive == false).Select(x => new ReferenceTableIdNameViewModel
            {
                Value = x.ReferenceTableId,
                Text = x.Name,
            });

            return ReferenceTableModel.ToList();
        }

        public List<ReferenceTableViewModel> GetAllReferenceTablesInactive()
        {
            var ReferenceTableModel = _context.ReferenceTables.Where(x => x.IsActive == false).Select(x => new ReferenceTableViewModel
            {
                ReferenceTableId = x.ReferenceTableId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                Classification = x.Classification,
            });

            return ReferenceTableModel.ToList();
        }

        public int DeleteReferenceTable(int id, int UserAccountId)
        {
            var ReferenceTableModel = _context.ReferenceTables.Where(x => x.ReferenceTableId == id).SingleOrDefault();
            ReferenceTableModel.DeletedByUserId = UserAccountId;
            ReferenceTableModel.DateDeleted = DateTime.Now;
            ReferenceTableModel.IsActive = false;


            _context.Update(ReferenceTableModel);
            _context.SaveChanges();

            return ReferenceTableModel.ReferenceTableId == 0 ? 0 : 1;

        }

        public int RestoreReferenceTable(int id, int UserAccountId)
        {
            var ReferenceTableModel = _context.ReferenceTables.Where(x => x.ReferenceTableId == id).SingleOrDefault();
            ReferenceTableModel.DeletedByUserId = UserAccountId;
            ReferenceTableModel.DateDeleted = DateTime.Now;
            ReferenceTableModel.IsActive = false;


            _context.Update(ReferenceTableModel);
            _context.SaveChanges();

            return ReferenceTableModel.ReferenceTableId == 0 ? 0 : 1;
        }
    }
}
