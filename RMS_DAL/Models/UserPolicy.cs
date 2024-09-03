using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class UserPolicy : BaseModel
    {
        [Key]
        public int UserPolicyId { get; set; }
        public int UserId { get; set; } // User: HR/TRAINER/MANAGER/ADMIN
        public int RoleId { get; set; } // Role: HR Specialist/ HR Manager/ TRAINER/ SUB-TRAINER/MANAGER/ ASSISTANT MANAGER/ SUPERADMIN/ADMIN

        #region Previous Design
        //public bool HRCreateAccess { get; set; }
        //public bool HRUpdateAccess { get; set; }
        //public bool HRReadAccess { get; set; }
        //public bool HRDeleteAccess { get; set; }
        //public bool HRRestoreAccess { get; set; }

        //public bool TRAINERCreateAccess { get; set; }
        //public bool TRAINERUpdateAccess { get; set; }
        //public bool TRAINERReadAccess { get; set; }
        //public bool TRAINERDeleteAccess { get; set; }
        //public bool TRAINERRestoreAccess { get; set; }

        //public bool MANAGERCreateAccess { get; set; }
        //public bool MANAGERUpdateAccess { get; set; }
        //public bool MANAGERReadAccess { get; set; }
        //public bool MANAGERDeleteAccess { get; set; }
        //public bool MANAGERRestoreAccess { get; set; }

        //public bool UMCreateAccess { get; set; }
        //public bool UMUpdateAccess { get; set; }
        //public bool UMReadAccess { get; set; }
        //public bool UMDeleteAccess { get; set; }
        //public bool UMRestoreAccess { get; set; }

        //public bool UMCreateAccess { get; set; }
        //public bool UMUpdateAccess { get; set; }
        //public bool UMReadAccess { get; set; }
        //public bool UMDeleteAccess { get; set; }
        //public bool UMRestoreAccess { get; set; }
        #endregion


    }
}
