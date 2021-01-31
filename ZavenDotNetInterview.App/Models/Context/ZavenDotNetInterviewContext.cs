using System.Data.Entity;

namespace ZavenDotNetInterview.App.Models.Context
{
    public class ZavenDotNetInterviewContext : DbContext, IZavenDotNetInterviewContext
    {
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Logs> Logs { get; set; }

        public ZavenDotNetInterviewContext(string connectionString) : base(connectionString)
        {
        }
    }
}