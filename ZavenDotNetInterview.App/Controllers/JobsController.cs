using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories;
using ZavenDotNetInterview.App.Services;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobProcessorService _jobProcessorService;
        private readonly IJobValueService _jobValueService;
        public JobsController(IJobProcessorService jobProcessorService, IJobValueService jobValueService)
        {
            _jobProcessorService = jobProcessorService;
            _jobValueService = jobValueService;
        }

        // GET: Tasks
        public ActionResult Index()
        {
            //using (ZavenDotNetInterviewContext _ctx = new ZavenDotNetInterviewContext())
            //{
            //    JobsRepository jobsRepository = new JobsRepository(_ctx);
            //    List<Job> jobs = jobsRepository.GetAllJobs();
            //    return View(jobs);
            //}

            return View();
        }

        // POST: Tasks/Process
        [HttpGet]
        public ActionResult Process()
        {
            _jobProcessorService.ProcessJobs();

            return RedirectToAction("Index");
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(string name, DateTime doAfter)
        {
            //try
            //{
            //    using (ZavenDotNetInterviewContext _ctx = new ZavenDotNetInterviewContext())
            //    {
            //        Job newJob = new Job() { Id = Guid.NewGuid(), DoAfter = doAfter, Name = name, Status = JobStatus.New };
            //        newJob = _ctx.Jobs.Add(newJob);
            //        _ctx.SaveChanges();
            //    }

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

            return View();
        }

        public ActionResult Details(Guid jobId)
        {
            return View();
        }
    }
}
