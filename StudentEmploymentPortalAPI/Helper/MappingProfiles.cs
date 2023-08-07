using AutoMapper;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobPost, JobPostDto>();
            CreateMap<DriversLicense, DriversLicenseDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Race, RaceDto>();
            CreateMap<Nationality, NationalityDto>();
            CreateMap<YearOfStudy, YearOfStudyDto>();

            // Exclude the 'Id' property in the 'Faculty' object when mapping to 'FacultyDto'
            CreateMap<Faculty, FacultyDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Qualification, QualificationsDto>();
            CreateMap<Qualification, CVQualificationsDto>();

            CreateMap<Referee, RefereesDto>();
            CreateMap<Referee, CVRefereesDto>();

            CreateMap<Experience, ExperiencesDto>();
            CreateMap<Experience, CVExperiencesDto>();

            CreateMap<Department, DepartmentDto>();

            // Combine both mappings for Student to StudentCVDto
            CreateMap<Student, StudentCVDto>()
    .ForMember(dest => dest.User, opt => opt.MapFrom(src => new CVApplicationUserDto
    {
        FirstName = src.User.FirstName,
        LastName = src.User.LastName,
        Email = src.User.UserName
    }))
    .ForMember(dest => dest.Department, opt => opt.MapFrom(src => new CVDepartmentDto
    {
        Name = src.Department.Name,
        Faculty = new FacultyDto // Create FacultyDto instance here
        {
            Name = src.Department.Faculty.Name // Assuming Faculty has a Name property
        }
    }));

            // Mapping for Student to StudentProfileDto
            CreateMap<Student, StudentProfileDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new ApplicationUserDto
                {
                    Id = src.User.Id,
                    FirstName = src.User.FirstName,
                    LastName = src.User.LastName,
                    Email = src.User.UserName
                }))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => new DepartmentDto
                {
                    Id = src.Department.Id,
                    Name = src.Department.Name,
                    Faculty = src.Department.Faculty,
                }));

            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUserDto, ApplicationUser>(); // Add this mapping


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
