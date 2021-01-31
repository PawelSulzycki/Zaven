using System;
using System.Collections.Generic;
using ZavenDotNetInterview.App.Enums;

namespace ZavenDotNetInterview.App.Models
{
    public class Jobs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public JobStatus Status { get; set; }
        public DateTime? DoAfter { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int FailureCounter { get; set; }
        public virtual List<Logs> Logs { get; set; }
    }
}