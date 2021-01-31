using System.Collections.Generic;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Repositories._Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        IEnumerable<Job> GetAll();
    }
}