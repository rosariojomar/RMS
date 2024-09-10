using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class RoleViewModel : BaseViewModel
    {
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleCreateViewModel : BaseViewModel
    {
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleUpdateViewModel : BaseViewModel
    {
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleIdNameViewModel : BaseViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

    }


}
