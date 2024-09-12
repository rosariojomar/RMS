using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IUnitService
    {
        List<UnitViewModel> GetAllUnits();
        List<UnitViewModel> GetAllUnitsInactive();

        int CreateUnit(UnitCreateViewModel userVM);
        int UpdateUnit(UnitUpdateViewModel userVM);
        int DeleteUnit(int id, int UserAccountId);
        int RestoreUnit(int id, int UserAccountId);

        List<UnitIdNameViewModel> GetAllNameWithId();
        UnitUpdateViewModel GetById(int Id);

    }
}
