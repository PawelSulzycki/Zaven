using System;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Enums;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Repositories._Interfaces;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App.Services
{
    public class JobProcessorService : IJobProcessorService
    {
        private readonly IJobsRepository _jobsRepository;
        private readonly ILogsRepository _logsRepository;

        public JobProcessorService(IJobsRepository jobsRepository, ILogsRepository logsRepository)
        {
            _jobsRepository = jobsRepository;
            _logsRepository = logsRepository;
        }

        public async Task ProcessJobs()
        {
            var statusesToProcess = new JobStatus[]
            {
                JobStatus.New,
                JobStatus.Failed
            };

            var jobsToProcess = _jobsRepository.Get(x => statusesToProcess.Contains(x.Status));

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
                currentjob.FailureCounter++;

                ChangeStatus(currentjob, JobStatus.Failed);
            }

            if (currentjob.FailureCounter == 5)
            {
                ChangeStatus(currentjob, JobStatus.Closed);
            }
        }

        private void ChangeStatus(Jobs job, JobStatus jobStatus)
        {
            job.Status = jobStatus;

            job.LastUpdatedAt = DateTime.Now;

            _jobsRepository.Update(job);

            _jobsRepository.Save();

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