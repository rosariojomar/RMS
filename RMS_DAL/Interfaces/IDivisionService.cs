using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IDivisionService
    {
        List<DivisionViewModel> GetAllDivisions();
        List<DivisionViewModel> GetAllDivisionsInactive();

        int CreateDivision(DivisionCreateViewModel userVM);
        int UpdateDivision(DivisionUpdateViewModel userVM);
        int DeleteDivision(int id, int UserAccountId);
        int RestoreDivision(int id, int UserAccountId);

        List<DivisionIdNameViewModel> GetAllNameWithId();
    }
}
