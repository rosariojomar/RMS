﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface IRMSContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }
}
