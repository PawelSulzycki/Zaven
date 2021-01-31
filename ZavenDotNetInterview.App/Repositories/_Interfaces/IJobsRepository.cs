using System.Collections.Generic;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Repositories._Interfaces
{
    public interface IJobsRepository
    {
        List<Job> GetAllJobs();
    }
}