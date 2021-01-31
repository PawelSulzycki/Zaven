using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavenDotNetInterview.App.Models.Context
{
    public interface IZavenDotNetInterviewContext
    {
        DbSet<Job> Jobs { get; set; }
        DbSet<Log> Logs { get; set; }


        int SaveChanges();
    }
}
