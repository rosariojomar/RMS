using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IReferenceTableService
    {
        List<ReferenceTableViewModel> GetAllReferenceTables();
        List<ReferenceTableViewModel> GetAllReferenceTablesInactive();

        int CreateReferenceTable(ReferenceTableCreateViewModel userVM);
        int UpdateReferenceTable(ReferenceTableUpdateViewModel userVM);
        int DeleteReferenceTable(int id, int UserAccountId);
        int RestoreReferenceTable(int id, int UserAccountId);

        List<ReferenceTableIdNameViewModel> GetAllNameWithId();

    }
}
