using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class ReferenceTableViewModel : BaseViewModel
    {
        public int ReferenceTableId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
    }

    public class ReferenceTableCreateViewModel : BaseViewModel
    {
        public int ReferenceTableId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
    }

    public class ReferenceTableUpdateViewModel : BaseViewModel
    {
        public int ReferenceTableId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
    }

    public class ReferenceTableIdNameViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

    }
    public class ReferenceTableDropDownViewModel
    {
        public int ReferenceTableId { get; set; }
        public string Name { get; set; }

    }
}
