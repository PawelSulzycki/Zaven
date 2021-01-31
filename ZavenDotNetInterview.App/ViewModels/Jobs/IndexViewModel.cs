using System;
using ZavenDotNetInterview.App.Enums;

namespace ZavenDotNetInterview.App.ViewModels.Jobs
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public JobStatus Status { get; set; }
    }
}