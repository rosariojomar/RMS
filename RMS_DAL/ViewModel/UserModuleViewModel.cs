using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class UserModuleViewModel
    {
        public int ModuleId { get; set; }
        public string ModuleDescription { get; set; }
        public List<int>? ModuleAccess { get; set; }
    }
}
