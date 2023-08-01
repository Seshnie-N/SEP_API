using AutoMapper;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobPost, JobPostDto>()
                .ForMember(dest => dest.JobType, opt => opt.MapFrom(src => src.JobType.Name))
                .ForMember(dest => dest.WeekHour, opt => opt.MapFrom(src => src.WeekHour.Range));    
        }
    }
}
