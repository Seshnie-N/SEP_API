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
                                                              //Map student details to post

            // CreateMap<Student, AddStudentDto>();
            //CreateMap<AddStudentDto, Student>();
            CreateMap<AddStudentDto, Student>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.IdNumber, opt => opt.MapFrom(src => src.IdNumber))
               .ForMember(dest => dest.DriversLicenseId, opt => opt.MapFrom(src => src.DriversLicenseId))
               .ForMember(dest => dest.CareerObjective, opt => opt.MapFrom(src => src.CareerObjective))
               .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
               .ForMember(dest => dest.RaceId, opt => opt.MapFrom(src => src.RaceId))
               .ForMember(dest => dest.IsSouthAfrican, opt => opt.MapFrom(src => src.IsSouthAfrican))
               .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(src => src.NationalityId))
               .ForMember(dest => dest.YearOfStudyId, opt => opt.MapFrom(src => src.YearOfStudyId))
               .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
               .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
               .ForMember(dest => dest.Achivements, opt => opt.MapFrom(src => src.Achivements))
               .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.Interests));



        }
    }
}
