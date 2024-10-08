﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class DivisionViewModel : BaseViewModel
    {
        public int DivisionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }

    }

    public class DivisionCreateViewModel : BaseViewModel
    {
        public int DivisionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
    }

    public class DivisionUpdateViewModel : BaseViewModel
    {
        public int DivisionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId{ get; set; }
    }

    public class DivisionIdNameViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

    }
}
