using RMS_DAL.Interfaces;
using RMS_DAL.Models;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Service.Impl
{
    public class PolicyService : IPolicyService
    {
        private readonly RMSContext _context;
        public PolicyService(RMSContext context)
        {
            _context = context;
        }
        public int CreatePolicy(PolicyCreateViewModel vm)
        {
            var policyModel = new UserPolicy()
            {
                RoleId = vm.RoleId,
                UserId = vm.UserId,
                UserPolicyCode = vm.PolicyCode,
                UserPolicyName = vm.PolicyName,
                UserPolicyDescription = vm.PolicyDescription,
                CreatedByUserId = vm.CreatedByUserId,
                DateCreated = vm.DateCreated,
                IsActive = true,
            };
            _context.Add(policyModel);

            foreach (var item in vm.PolicyTransact)
            {
                var policyTransactModel = new UserPolicyTransact()
                {
                    UserPolicyId = policyModel.UserPolicyId,
                    ModuleId = item.ModuleId,
                    CreateAccess = item.CreateAccess,
                    ReadAccess = item.ReadAccess,
                    UpdateAccess = item.UpdateAccess,
                    DeleteAccess = item.DeleteAccess,
                    RestoreAccess = item.RestoreAccess,
                    CreatedByUserId = vm.CreatedByUserId,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
                _context.Add(policyTransactModel);
            }
            _context.SaveChangesAsync();

            return policyModel.UserPolicyId == 0 ? 0 : 1;

        }

        public int UpdatePolicy(PolicyUpdateViewModel vm)
        {
            var policyModel = _context.UserPolicies.Where(x => x.UserPolicyId == vm.UserPolicyId).SingleOrDefault();
            policyModel.UserPolicyCode = vm.PolicyCode;
            policyModel.UserPolicyName = vm.PolicyName;
            policyModel.UserPolicyDescription = vm.PolicyDescription;
            policyModel.RoleId = vm.RoleId;
            policyModel.UserId = vm.UserId;
            policyModel.CreatedByUserId = vm.CreatedByUserId;
            policyModel.DateCreated = vm.DateCreated;
            policyModel.IsActive = true;
            _context.Update(policyModel);

            foreach (var item in vm.PolicyTransact)
            {
                var policyTransactModel = _context.UserPolicyTransactions.Where(x => x.UserPolicyTransactId == item.UserPolicyTransactId).SingleOrDefault();
                policyTransactModel.ModuleId = item.ModuleId;
                policyTransactModel.CreateAccess = item.CreateAccess;
                policyTransactModel.ReadAccess = item.ReadAccess;
                policyTransactModel.UpdateAccess = item.UpdateAccess;
                policyTransactModel.DeleteAccess = item.DeleteAccess;
                policyTransactModel.RestoreAccess = item.RestoreAccess;
                policyTransactModel.CreatedByUserId = vm.CreatedByUserId;
                policyTransactModel.DateCreated = DateTime.Now;
                policyTransactModel.IsActive = true;
                _context.Update(policyTransactModel);
            }

            _context.SaveChangesAsync();

            return policyModel.UserPolicyId == 0 ? 0 : 1;
        }
        public int DeletePolicy(int id, int UserAccountId)
        {
            var policyModel = _context.UserPolicies.Where(x => x.UserPolicyId == id).SingleOrDefault();
            policyModel.DeletedByUserId = UserAccountId;
            policyModel.DateDeleted = DateTime.Now;
            policyModel.IsActive = false;


            _context.Update(policyModel);
            _context.SaveChangesAsync();

            return policyModel.UserPolicyId == 0 ? 0 : 1;
        }

        public int RestorePolicy(int id, int UserAccountId)
        {
            var policyModel = _context.UserPolicies.Where(x => x.UserPolicyId == id).SingleOrDefault();
            policyModel.DeletedByUserId = UserAccountId;
            policyModel.DateDeleted = DateTime.Now;
            policyModel.IsActive = true;

            _context.Update(policyModel);
            _context.SaveChangesAsync();

            return policyModel.UserPolicyId == 0 ? 0 : 1;
        }

        public List<PolicyViewModel> GetAllActive()
        {
            var policyModel = _context.UserPolicies.Where(x => x.IsActive == true).Select(x => new PolicyViewModel
            {
                RoleId = x.RoleId,
                UserId = x.UserId,
                PolicyCode = x.UserPolicyCode,
                PolicyName = x.UserPolicyName,
                PolicyDescription = x.UserPolicyDescription,
                CreatedByUserId = x.CreatedByUserId,
                DateCreated = x.DateCreated,
                IsActive = true,

            });

            return policyModel.ToList();
        }

        public List<PolicyViewModel> GetAllInactive()
        {
            var policyModel = _context.UserPolicies.Where(x => x.IsActive == false).Select(x => new PolicyViewModel
            {
                RoleId = x.RoleId,
                UserId = x.UserId,
                PolicyCode = x.UserPolicyCode,
                PolicyName = x.UserPolicyName,
                PolicyDescription = x.UserPolicyDescription,
                CreatedByUserId = x.CreatedByUserId,
                DateCreated = x.DateCreated,
                IsActive = true,

            });

            return policyModel.ToList();
        }


    }
}
