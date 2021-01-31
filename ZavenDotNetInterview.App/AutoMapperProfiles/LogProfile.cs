using AutoMapper;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.ViewModels.Jobs;

namespace ZavenDotNetInterview.App.AutoMapperProfiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Logs, LogViewModel>();
        }
    }
}