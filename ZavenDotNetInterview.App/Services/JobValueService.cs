using System;
using System.Collections.Generic;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Repositories._Interfaces;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App.Services
{
    public class JobValueService : IJobValueService
    {
        private readonly IJobsRepository _jobRepository;

        public JobValueService(IJobsRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public void Add(string name, DateTime? doAfter)
        {
            try
            {
                _jobRepository.Insert(name, doAfter);

                _jobRepository.Save();
            }
            catch (Exception ex)
            {
                //TODO dissuced implemention of logging excetions
            }
        }

        public IEnumerable<Job> GetAll()
        {
            var result = _jobRepository.GetAll();

            return result;
        }

        public bool IsExist(string name)
        {
            var result = _jobRepository.IsExist(x => x.Name == name);

            return result;
        }
    }
}