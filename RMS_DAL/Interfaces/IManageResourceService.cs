using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IManageResourceService
    {
        int CreateResource(ManageResourceCreateViewModel vm);
        int UpdateResource(ManageResourceUpdateViewModel vm);
        int DeleteResource(int id, int UserAccountId);
        int RestoreResource(int id, int UserAccountId);
        List<ManageResourceIndexViewModel> GetAllActive();
        List<ManageResourceIndexViewModel> GetAllInactive();

    }
}
