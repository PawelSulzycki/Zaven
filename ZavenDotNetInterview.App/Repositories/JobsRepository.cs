using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories._Interfaces;

namespace ZavenDotNetInterview.App.Repositories
{
    public class JobsRepository : Repository<Job>, IJobsRepository
    {
        public JobsRepository(IZavenDotNetInterviewContext ctx) : base(ctx) 
        {
        }

        public IEnumerable<Job> GetAll()
        {
            var result = _ctx.Jobs;

            return result;
        }

        public Guid Insert(string name, DateTime? doAfter)
        {
            var job = new Job
            {
                Id = Guid.NewGuid(),
                Name = name,
                DoAfter = doAfter,
                Status = JobStatus.New
            };

            Insert(job);

            return job.Id;
        }

        public bool IsExist(Expression<Func<Job, bool>> filter)
            => _ctx.Jobs
                .Where(filter)
                .Any();
    }
}