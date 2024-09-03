using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class Person : BaseModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Middlename { get; set; }
        public string Position { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public int UnitId { get; set; }
        public bool IsReference { get; set; }
    }
}
