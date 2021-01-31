using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Repositories._Interfaces
{
    public interface IJobsRepository : IRepository<Job>
    {
        IEnumerable<Job> GetAll();
        bool IsExist(Expression<Func<Job, bool>> filter);
        Guid Insert(string name, DateTime? doAfter);
    }
}