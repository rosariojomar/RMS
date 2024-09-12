using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IPolicyService 
    {
        int CreatePolicy(PolicyCreateViewModel vm);
        int UpdatePolicy(PolicyUpdateViewModel vm);
        int DeletePolicy(int id, int UserAccountId);
        int RestorePolicy(int id, int UserAccountId);
        List<PolicyViewModel> GetAllActive();
        List<PolicyViewModel> GetAllInactive();
        PolicyUpdateViewModel GetById(int Id);
    }
}
