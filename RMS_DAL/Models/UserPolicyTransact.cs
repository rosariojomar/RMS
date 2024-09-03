using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class UserPolicyTransact : BaseModel
    {
        [Key]
        public int UserPolicyTransactId { get; set; }
        public int UserPolicyId { get; set; }

        public int ModuleId { get; set; }
        public bool CreateAccess { get; set; }
        public bool UpdateAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool ReadAccess { get; set; }
        public bool RestoreAccess { get; set; }


    }
}
