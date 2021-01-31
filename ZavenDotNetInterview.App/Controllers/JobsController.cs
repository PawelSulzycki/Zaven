using AutoMapper;
using System;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;
        public JobsController(IJobProcessorService jobProcessorService, IJobValueService jobValueService, IMapper mapper)
        {
            _jobProcessorService = jobProcessorService;
            _jobValueService = jobValueService;
            _mapper = mapper;
        }

        // GET: Tasks
        public ActionResult Index()
        {
            var jobs = _jobValueService.GetAll();

            var viewModels = _mapper.Map<IEnumerable<IndexViewModel>>(jobs);

            return View(viewModels);
        }

        // POST: Tasks/Process
        [HttpPost]
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
            var detail = _jobValueService.GetDetails(jobId);

            var viewModel = _mapper.Map<DetailsViewModel>(detail);

            return View(viewModel);
        }
    }
}
