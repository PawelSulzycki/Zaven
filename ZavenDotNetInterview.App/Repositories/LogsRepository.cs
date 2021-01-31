using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories._Interfaces;

namespace ZavenDotNetInterview.App.Repositories
{
    public class LogsRepository : Repository<Logs>, ILogsRepository
    {
        public LogsRepository(IZavenDotNetInterviewContext ctx) : base(ctx)
        {
        }

        public override void Insert(Logs entity)
        {
            entity.Id = Guid.NewGuid();

            entity.CreatedAt = DateTime.UtcNow;

            base.Insert(entity);
        }
    }
}