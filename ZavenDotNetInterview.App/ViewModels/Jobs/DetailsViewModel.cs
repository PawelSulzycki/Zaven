using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.ViewModels.Jobs
{
    public class DetailsViewModel
    {
        public string Name { get; set; }
        public JobStatus Status { get; set; }
        public string ProcessingDate { get; set; }
        public IEnumerable<LogViewModel> Logs { get; set; }
    }
}