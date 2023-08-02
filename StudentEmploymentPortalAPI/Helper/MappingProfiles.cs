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
            CreateMap<Student, StudentProfileDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new ApplicationUserDto
                {
                    UserId = src.User.Id,
                    FirstName = src.User.FirstName,
                    LastName = src.User.LastName,
                    Email = src.User.UserName

                }))
                 .ForMember(dest => dest.Department, opt => opt.MapFrom(src => new DepartmentDto
                {
                    DepartmentId = src.Department.Id,
                    Name = src.Department.Name,
                    Faculty = src.Department.Faculty,

                }));
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUserDto, ApplicationUser>(); // Add this mapping
        }
    }
}
