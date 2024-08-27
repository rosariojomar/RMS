using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class BaseModel
    {
        public DateTime DateCreated { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedByUserId { get; set; }

        public DateTime DateDeleted { get; set; }
        public int DeletedByUserId { get; set; }

        public DateTime DateRestore { get; set; }
        public int RestoredByUserId { get; set; }
        public bool IsActive { get; set; }


    }
}
