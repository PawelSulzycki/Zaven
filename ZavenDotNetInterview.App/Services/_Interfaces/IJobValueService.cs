using System.Collections.Generic;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Services._Interfaces
{
    public interface IJobValueService
    {
        IEnumerable<Job> GetAll();
    }
}
