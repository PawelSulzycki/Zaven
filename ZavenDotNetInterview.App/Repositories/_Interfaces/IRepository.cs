using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZavenDotNetInterview.App.Repositories._Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        void Delete(object id);
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Save();
    }
}
