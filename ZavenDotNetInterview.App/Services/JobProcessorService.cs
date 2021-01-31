using System;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Repositories._Interfaces;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App.Services
{
    public class JobProcessorService : IJobProcessorService
    {
        private readonly IJobsRepository _jobRepository;
        private readonly ILogsRepository _logsRepository;

        public JobProcessorService(IJobsRepository jobRepository, ILogsRepository logsRepository)
        {
            _jobRepository = jobRepository;
            _logsRepository = logsRepository;
        }

        public async Task ProcessJobs()
        {
            var statusesToProcess = new JobStatus[]
            {
                JobStatus.New,
                JobStatus.Failed
            };

            var jobsToProcess = _jobRepository.Get(x => statusesToProcess.Contains(x.Status));

            var tasks = jobsToProcess.Select(async currentjob =>
            {
                await SetJobStatus(currentjob);
            });

            await Task.WhenAll(tasks);
        }

        private async Task SetJobStatus(Jobs currentjob)
        {
            var result = await this.ProcessJob(currentjob);

            if (result)
            {
                ChangeStatus(currentjob, JobStatus.Done);
            }
            else
            {
                ChangeStatus(currentjob, JobStatus.Failed);
            }
        }

        private void ChangeStatus(Jobs job, JobStatus jobStatus)
        {
            job.Status = jobStatus;

            job.LastUpdatedAt = DateTime.Now;

            _jobRepository.Update(job);

            _jobRepository.Save();

            var log = new Logs
            {
                JobId = job.Id,
                Description = string.Format(UserMessages.JobChangeStatus, job.Id, job.Name, jobStatus)
            };

            _logsRepository.Insert(log);

            _logsRepository.Save();
        }

        private async Task<bool> ProcessJob(Jobs job)
        {
            Random rand = new Random();
            if (rand.Next(10) < 5)
            {
                await Task.Delay(2000);
                return false;
            }
            else
            {
                await Task.Delay(1000);
                return true;
            }
        }
    }
}