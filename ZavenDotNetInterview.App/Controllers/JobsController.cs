using System;
using System.Linq;
using System.Web.Mvc;
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
            var jobs = _jobValueService.GetAll().ToList();

            return View(jobs);
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
