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
        PersonViewModel GetPersonById(int id);
    }
}
