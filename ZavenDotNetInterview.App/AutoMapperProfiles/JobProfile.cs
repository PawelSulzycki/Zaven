﻿using AutoMapper;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.ViewModels.Jobs;

namespace ZavenDotNetInterview.App.AutoMapperProfiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Jobs, DetailsViewModel>()
                .ForMember(
                    dest => dest.ProcessingDate,
                    opt => opt.MapFrom(src => src.DoAfter.HasValue ? src.DoAfter.Value.ToShortDateString() : "No date"))
                .ForMember(
                    dest => dest.CreationDate,
                    opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Jobs, IndexViewModel>();
        }
    }
}