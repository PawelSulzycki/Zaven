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
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(IZavenDotNetInterviewContext ctx) : base(ctx) 
        {
        }

        public IEnumerable<Job> GetAll()
        {
            var result = _ctx.Jobs;

            return result;
        }
    }
}