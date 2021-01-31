using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ZavenDotNetInterview.App.Enums;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories._Interfaces;

namespace ZavenDotNetInterview.App.Repositories
{
    public class JobsRepository : Repository<Jobs>, IJobsRepository
    {
        public JobsRepository(IZavenDotNetInterviewContext ctx) : base(ctx) 
        {
        }

        public IEnumerable<Jobs> GetAll()
        {
            var result = _ctx.Jobs;

            return result;
        }

        public Jobs GetOneWithLogs(Expression<Func<Jobs, bool>> filter)
        {
            var result = _ctx.Jobs
                .Include(x => x.Logs)
                .Where(filter)
                .FirstOrDefault();

            return result;
        }

        public Guid Insert(string name, DateTime? doAfter)
        {
            var job = new Jobs
            {
                Id = Guid.NewGuid(),
                Name = name,
                DoAfter = doAfter,
                Status = JobStatus.New,
                CreatedAt = DateTime.Now
            };

            Insert(job);

            return job.Id;
        }

        public bool IsExist(Expression<Func<Jobs, bool>> filter)
            => _ctx.Jobs
                .Where(filter)
                .Any();
    }
}