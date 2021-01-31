using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories._Interfaces;

namespace ZavenDotNetInterview.App.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal IZavenDotNetInterviewContext _ctx;

        public Repository(IZavenDotNetInterviewContext ctx)
        {
            _ctx = ctx;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _ctx.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _ctx.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return _ctx.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
        }

        public virtual void Save()
        {
            _ctx.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _ctx.Set<TEntity>().Attach(entityToUpdate);

            _ctx.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}