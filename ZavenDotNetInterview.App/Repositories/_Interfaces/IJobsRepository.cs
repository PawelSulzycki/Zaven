using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Repositories._Interfaces
{
    public interface IJobsRepository : IRepository<Jobs>
    {
        IEnumerable<Jobs> GetAll();
        bool IsExist(Expression<Func<Jobs, bool>> filter);
        Guid Insert(string name, DateTime? doAfter);
        Jobs GetOneWithLogs(Expression<Func<Jobs, bool>> filter);
    }
}