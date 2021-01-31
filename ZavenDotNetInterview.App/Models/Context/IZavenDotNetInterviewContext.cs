using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavenDotNetInterview.App.Models.Context
{
    public interface IZavenDotNetInterviewContext
    {
        DbSet<Job> Jobs { get; set; }
        DbSet<Log> Logs { get; set; }


        int SaveChanges();
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
