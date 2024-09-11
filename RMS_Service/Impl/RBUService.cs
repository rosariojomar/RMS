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
    public class RBUService : IRBUService
    {
        private readonly RMSContext _context;
        public RBUService(RMSContext context)
        {
            _context = context;
        }

        public int CreateRBU(RBUCreateViewModel rbuVM)
        {
            var rbuModel = new RBU()
            {
                Code = rbuVM.Code,
                Name = rbuVM.Name,
                Description = rbuVM.Description,
                CreatedByUserId = rbuVM.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = rbuVM.IsActive,
            };

            _context.Add(rbuModel);
            _context.SaveChanges();

            return rbuModel.RBUId == 0 ? 0 : 1;
        }

        public int UpdateRBU(RBUUpdateViewModel rbuVM)
        {
            var rbuModel = _context.RBU.Where(x => x.RBUId == rbuVM.RBUId).SingleOrDefault();
            rbuModel.Code = rbuVM.Code;
            rbuModel.Name = rbuVM.Name;
            rbuModel.Description = rbuVM.Description;
            rbuModel.UpdatedByUserId = rbuVM.UpdatedByUserId;
            rbuModel.DateUpdated = DateTime.Now;
            rbuModel.IsActive = rbuVM.IsActive;

            _context.Update(rbuModel);
            _context.SaveChanges();

            return rbuModel.RBUId == 0 ? 0 : 1;
        }

        public List<RBUViewModel> GetAllRbus()
        {
            var rbuModel = _context.RBU.Where(x => x.IsActive == true).Select(x => new RBUViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
            });

            return rbuModel.ToList();
        }

        public List<RBUIdNameViewModel> GetAllNameWithId()
        {
            var rbuModel = _context.RBU.Where(x => x.IsActive == true).Select(x => new RBUIdNameViewModel
            {
                Value = x.RBUId,
                Text = x.Name,
            });

            return rbuModel.ToList();
        }

        public List<RBUViewModel> GetAllRBUsInactive()
        {
            var rbuModel = _context.RBU.Where(x => x.IsActive == false).Select(x => new RBUViewModel
            {
                RBUId = x.RBUId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
            });

            return rbuModel.ToList();
        }

        public int DeleteRBU(int id, int UserAccountId)
        {
            var rbuModel = _context.RBU.Where(x => x.RBUId == id).SingleOrDefault();
            rbuModel.DeletedByUserId = UserAccountId;
            rbuModel.DateDeleted = DateTime.Now;
            rbuModel.IsActive = false;


            _context.Update(rbuModel);
            _context.SaveChanges();

            return rbuModel.RBUId == 0 ? 0 : 1;

        }

        public int RestoreRBU(int id, int UserAccountId)
        {
            var rbuModel = _context.RBU.Where(x => x.RBUId == id).SingleOrDefault();
            rbuModel.DeletedByUserId = UserAccountId;
            rbuModel.DateDeleted = DateTime.Now;
            rbuModel.IsActive = false;


            _context.Update(rbuModel);
            _context.SaveChanges();

            return rbuModel.RBUId == 0 ? 0 : 1;
        }
    }
}
