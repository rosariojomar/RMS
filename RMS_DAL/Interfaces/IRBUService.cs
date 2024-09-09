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

        int CreateRBU(RBUCreateViewModel rbuVM);
        int UpdateRBU(RBUUpdateViewModel rbuVM);

        List<RBUIdNameViewModel> GetAllNameWithId();

    }
}
