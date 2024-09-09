using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class EmployeeSkills : BaseModel
    {
        [Key]
        public int EmployeeSkillId { get; set; }
        public int PersonId { get; set; }
        public string SkillName { get; set; }
        public int SkillRating { get; set; }
        public int SkillExpInMonths { get; set; }

    }
}
