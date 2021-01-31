using System;
using System.Collections.Generic;
using System.Linq;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Repositories._Interfaces;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App.Services
{
    public class JobValueService : IJobValueService
    {
        private readonly IJobsRepository _jobsRepository;
        private readonly ILogsRepository _logsRepository;

        public JobValueService(IJobsRepository jobsRepository, ILogsRepository logsRepository)
        {
            _jobsRepository = jobsRepository;
            _logsRepository = logsRepository;
        }

        public void Add(string name, DateTime? doAfter)
        {
            try
            {
                var idJob = _jobsRepository.Insert(name, doAfter);

                _jobsRepository.Save();

                var log = new Logs
                {
                    JobId = idJob,
                    Description = string.Format(UserMessages.NewJobAdded, idJob, name, DateTime.Now)
                };

                _logsRepository.Insert(log);

                _logsRepository.Save();
            }
            catch (Exception ex)
            {
                //TODO dissuced implemention of logging excetions
            }
        }

        public IEnumerable<Jobs> GetAll()
        {
            var result = _jobsRepository
                .GetAll()
                .OrderByDescending(x=> x.CreatedAt);

            return result;
        }

        public Jobs GetDetails(Guid idJob)
        {
            var job = _jobsRepository
                .GetOneWithLogs(x => x.Id == idJob);

            job.Logs = job.Logs
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            return job;
        }

        public bool IsExist(string name)
        {
            var result = _jobsRepository.IsExist(x => x.Name == name);

            return result;
        }
    }
}