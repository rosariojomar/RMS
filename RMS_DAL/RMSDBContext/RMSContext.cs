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

    }
}
