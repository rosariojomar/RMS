using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class UserCreateViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class UserUpdateViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class UserIdNameViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

    }


}
