using Microsoft.EntityFrameworkCore;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IUserAccountService
    {
      
        UserAccountViewModel Login(string username, string password);


    }
}
