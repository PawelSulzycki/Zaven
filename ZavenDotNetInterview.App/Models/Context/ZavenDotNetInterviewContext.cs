using System.Data.Entity;

namespace ZavenDotNetInterview.App.Models.Context
{
    public class ZavenDotNetInterviewContext : DbContext, IZavenDotNetInterviewContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Log> Logs { get; set; }

        public ZavenDotNetInterviewContext(string connectionString) : base(connectionString)
        {
        }
    }
}