using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public virtual List<Logs> Logs { get; set; }
    }

    public enum JobStatus
    {
        Failed = -1,
        New = 0,
        InProgress = 1,
        Done = 2
    }
}