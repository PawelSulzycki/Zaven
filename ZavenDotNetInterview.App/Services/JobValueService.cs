using System.Collections.Generic;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Repositories._Interfaces;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App.Services
{
    public class JobValueService : IJobValueService
    {
        private readonly IJobRepository _jobRepository;

        public JobValueService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public IEnumerable<Job> GetAll()
        {
            var result = _jobRepository.GetAll();

            return result;
        }
    }
}