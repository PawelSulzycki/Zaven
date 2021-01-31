﻿using System;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Extensions;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories;
using ZavenDotNetInterview.App.Repositories._Interfaces;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App.Services
{
    public class JobProcessorService : IJobProcessorService
    {
        private IZavenDotNetInterviewContext _ctx;

        public JobProcessorService(IZavenDotNetInterviewContext ctx)
        {
            _ctx = ctx;
        }

        public void ProcessJobs()
        {
            IJobRepository jobsRepository = new JobRepository(_ctx);
            var allJobs = jobsRepository.GetAll();
            var jobsToProcess = allJobs.Where(x => x.Status == JobStatus.New).ToList();

            jobsToProcess.ForEach(job => job.ChangeStatus(JobStatus.InProgress));
                        
            _ctx.SaveChanges();

            Parallel.ForEach(jobsToProcess, (currentjob) =>
            {
                new Task(async () =>
                {
                    bool result = await this.ProcessJob(currentjob).ConfigureAwait(false);
                    if (result)
                    {
                        currentjob.ChangeStatus(JobStatus.Done);
                    }
                    else
                    {
                        _ctx.SaveChanges();
                        currentjob.ChangeStatus(JobStatus.Failed);
                    }
                }).Start();
            });

            _ctx.SaveChanges();
        }

        private async Task<bool> ProcessJob(Job job)
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