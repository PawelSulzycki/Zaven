using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZavenDotNetInterview.App.Services._Interfaces;
using ZavenDotNetInterview.App.ViewModels.Jobs;

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
        public async Task<ActionResult> Process()
        {
            await _jobProcessorService.ProcessJobs();

            return RedirectToAction("Index");
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(CreateViewModel viewModel)
        {
            var isExist = _jobValueService.IsExist(viewModel.Name);

            if (isExist)
            {
                ViewBag.ErrorMessage = UserMessages.JobExist;

                return View();
            }
            else
            {
                _jobValueService.Add(viewModel.Name, viewModel.DoAfter);

                ViewBag.SuccessMessage = UserMessages.JobSave;
            }

            return View();
        }

        public ActionResult Details(Guid jobId)
        {
            return View();
        }
    }
}
