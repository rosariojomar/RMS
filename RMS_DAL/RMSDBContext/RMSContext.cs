using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RMS_DAL.Interfaces;
using RMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.RMSDBContext
{
    public partial class RMSContext : DbContext, IRMSContext
    {
        public RMSContext()
        {

        }
        public RMSContext(DbContextOptions<RMSContext> options)
    : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<RBU> RBU { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserPolicy> UserPolicies { get; set; }
        public virtual DbSet<UserPolicyTransact> UserPolicyTransactions { get; set; }



    }
}
