using System;
using System.Collections.Generic;
using ZavenDotNetInterview.App.Enums;

namespace ZavenDotNetInterview.App.ViewModels.Jobs
{
    public class DetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public JobStatus Status { get; set; }
        public string ProcessingDate { get; set; }
        public int FailureCounter { get; set; }
        public DateTime CreationDate { get; set; }
        public IEnumerable<LogViewModel> Logs { get; set; }
    }
}