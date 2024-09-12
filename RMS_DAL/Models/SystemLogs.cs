using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class SystemLogs : BaseModel
    {
        [Key]
        public int SystemLogId { get; set; }
        public string Action { get; set; }
        public string Module { get; set; }
        public string UserAccount { get; set; }
        public string Result { get; set; }

    }
}
