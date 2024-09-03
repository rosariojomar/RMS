using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class Unit : BaseModel
    {
        [Key]
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }

    }
}
