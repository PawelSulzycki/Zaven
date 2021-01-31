using ZavenDotNetInterview.App.Enums;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Extensions
{
    internal static class JobExtension
    {
        public static void ChangeStatus(this Jobs job, JobStatus newStatus)
        {
            job.Status = newStatus;
        }
    }
}