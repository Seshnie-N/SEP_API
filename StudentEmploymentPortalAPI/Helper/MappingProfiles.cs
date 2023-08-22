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
            CreateMap<StudentApplication, ApplicationResponseDto>()
                .ForMember(dest => dest.ApplicationStatus, opt => opt.MapFrom(src => src.ApplicationStatus.Name))
                .ForMember(dest => dest.JobPost, opt => opt.MapFrom(src => src.JobPost));
            CreateMap<StudentApplication, CompleteApplicationResponseDto>()
                .ForMember(dest => dest.ApplicationStatus, opt => opt.MapFrom(src => src.ApplicationStatus.Name))
                .ForMember(dest => dest.JobPost, opt => opt.MapFrom(src => src.JobPost))
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents));
            CreateMap<StudentApplication, ApplicationDto>();
            CreateMap<ApplicationDto, StudentApplication>();
        }
    }
}
