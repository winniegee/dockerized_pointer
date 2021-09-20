using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    public interface IDbContext:IDisposable
    {
       
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }

    
}
