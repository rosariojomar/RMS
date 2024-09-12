using RMS_DAL.Models;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IPersonService
    {
        int CreatePerson(PersonCreateViewModel vm);
        int UpdatePerson(PersonUpdateViewModel vm);
        int DeletePerson(int id, int UserAccountId);
        int RestorePerson(int id, int UserAccountId);
        PersonUpdateViewModel GetPersonById(int id);
        List<PersonViewModel> GetAll();
    }
}
