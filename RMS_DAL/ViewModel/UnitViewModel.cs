using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class UnitViewModel : BaseViewModel
    {
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }

    }

    public class UnitCreateViewModel : BaseViewModel
    {
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
    }

    public class UnitUpdateViewModel : BaseViewModel
    {
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
    }

    public class UnitIdNameViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

    }
}
