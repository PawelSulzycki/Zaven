using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories._Interfaces;

namespace ZavenDotNetInterview.App.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ZavenDotNetInterviewContext _ctx;

        public JobsRepository(ZavenDotNetInterviewContext ctx)
        {
            _ctx = ctx;
        }

        public List<Job> GetAllJobs()
        {
            return _ctx.Jobs.ToList();
        }
    }
}