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

//ApplicationUser
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUserDto, ApplicationUser>(); 

//Students
            CreateMap<UpdateStudentProfileDto, Student>();
            CreateMap<StudentProfileDto, Student>();
            CreateMap<Student, StudentProfileDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new ApplicationUserDto
                {
                    Id = src.User.Id,
                    FirstName = src.User.FirstName,
                    LastName = src.User.LastName,
                    Email = src.User.UserName
                }));
                // .ForMember(dest => dest.Department, opt => opt.MapFrom(src => new DepartmentDto
                // {
                //     Id = src.Department.Id,
                //     Name = src.Department.Name,
                //     Faculty = src.Department.Faculty,
                // }));
            
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
                Faculty = new FacultyDto
                {
                    Name = src.Department.Faculty.Name 
                }
            }));


//Qualifications

            CreateMap<AddQualificationDto, Qualification>();
            CreateMap<Qualification, QualificationDto>();
            CreateMap<QualificationDto, Qualification>();
            CreateMap<Qualification, QualificationsDto>();
            CreateMap<Qualification, CVQualificationsDto>();

 //Experiences          

            CreateMap<AddExperienceDto, Experience>();
            CreateMap<ExperienceDto, Experience>();
            CreateMap<Experience, ExperienceDto>();
            CreateMap<Experience, ExperiencesDto>();
            CreateMap<Experience, CVExperiencesDto>();

//Referees

            CreateMap<AddRefereeDto, Referee>();
            CreateMap<RefereeDto, Referee>();
            CreateMap<Referee, RefereeDto>();
            CreateMap<Referee, RefereesDto>();
            CreateMap<Referee, CVRefereesDto>();

//Others

            CreateMap<DriversLicense, DriversLicenseDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Race, RaceDto>();
            CreateMap<Nationality, NationalityDto>();
            CreateMap<YearOfStudy, YearOfStudyDto>(); 
            CreateMap<Department, DepartmentDto>();
            CreateMap<Faculty, FacultyDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
           
        }
    }
}
