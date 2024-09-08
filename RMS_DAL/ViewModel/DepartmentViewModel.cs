using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class DepartmentViewModel : BaseViewModel
    {
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }


    }
}
