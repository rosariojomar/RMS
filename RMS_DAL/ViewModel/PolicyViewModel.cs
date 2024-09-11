using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class PolicyViewModel : BaseViewModel
    {
        public int UserPolicyId { get; set; }
        public string PolicyCode { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public int UserId { get; set; } // User: HR/TRAINER/MANAGER/ADMIN
        public string? UserType { get; set; }
        public int RoleId { get; set; } // Role: HR Specialist/ HR Manager/ TRAINER/ SUB-TRAINER/MANAGER/ ASSISTANT MANAGER/ SUPERADMIN/ADMIN
        public string? Role { get; set; }
        public List<PolicyTransactViewModel> PolicyTransact { get; set; } = new List<PolicyTransactViewModel>();

    }

    public class PolicyCreateViewModel : BaseViewModel
    {
        public int UserPolicyId { get; set; }
        public string PolicyCode { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public int UserId { get; set; } // User: HR/TRAINER/MANAGER/ADMIN
        public int RoleId { get; set; } // Role: HR Specialist/ HR Manager/ TRAINER/ SUB-TRAINER/MANAGER/ ASSISTANT MANAGER/ SUPERADMIN/ADMIN
        public List<PolicyTransactViewModel> PolicyTransact { get; set; } = new List<PolicyTransactViewModel>();

    }

    public class PolicyUpdateViewModel : BaseViewModel
    {
        public int UserPolicyId { get; set; }
        public string PolicyCode { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public int UserId { get; set; } // User: HR/TRAINER/MANAGER/ADMIN
        public int RoleId { get; set; } // Role: HR Specialist/ HR Manager/ TRAINER/ SUB-TRAINER/MANAGER/ ASSISTANT MANAGER/ SUPERADMIN/ADMIN
        public List<PolicyTransactViewModel> PolicyTransact { get; set; }

    }

}
