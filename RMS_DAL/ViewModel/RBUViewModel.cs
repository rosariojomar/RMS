using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class RBUViewModel : BaseViewModel
    {
        public int RBUId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RBUCreateViewModel : BaseViewModel
    {
        public int RBUId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RBUUpdateViewModel : BaseViewModel
    {
        public int RBUId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RBUIdNameViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

    }



}
