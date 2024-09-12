using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IRBUService
    {
        List<RBUViewModel> GetAllRbus();
        List<RBUViewModel> GetAllRBUsInactive();

        int CreateRBU(RBUCreateViewModel userVM);
        int UpdateRBU(RBUUpdateViewModel userVM);
        int DeleteRBU(int id, int UserAccountId);
        int RestoreRBU(int id, int UserAccountId);

        List<RBUIdNameViewModel> GetAllNameWithId();
        RBUUpdateViewModel GetById(int Id);

    }
}
