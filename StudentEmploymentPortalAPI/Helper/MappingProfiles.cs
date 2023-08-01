using AutoMapper;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobPost, JobPostDto>();
            CreateMap<StudentApplication, ApplicationDto>();
            CreateMap<ApplicationDto, StudentApplication>();
        }
    }
}
