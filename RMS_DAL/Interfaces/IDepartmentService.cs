using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IDepartmentService
    {
        List<DepartmentViewModel> GetAllDept();
        List<DepartmentViewModel> GetAllDeptInactive();

        int CreateDept(DepartmentCreateViewModel userVM);
        int UpdateDept(DepartmentUpdateViewModel userVM);
        int DeleteDept(int id, int UserAccountId);
        int RestoreDept(int id, int UserAccountId);

        List<DepartmentIdNameViewModel> GetAllNameWithId();
    }
}
