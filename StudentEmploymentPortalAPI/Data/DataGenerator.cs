using AutoMapper;
using Bogus;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;
using StudentEmploymentPortalAPI.Services;

namespace SEP.Data
{
    public class DataGenerator
    {
        private readonly DataContext _context;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAuthService _authService;

        public DataGenerator(DataContext context, ILookupRepository lookupRepository, IAuthService authService) 
        {
            Randomizer.Seed = new Random(1969);
            _context = context;
            _lookupRepository = lookupRepository;
            _authService = authService;
        }
        
        private Faker<Employer> GetEmployerGenerator()
        {
            var businessTypes = _context.BusinessTypes.ToList();
            var employerTypes = _context.EmployerTypes.ToList();
            var employerStatuses = _context.EmployerStatuses.ToList();
            return new Faker<Employer>()
                .RuleFor(e => e.Id, f => f.Random.Guid())
                .RuleFor(e => e.Title, f => f.Name.Prefix())
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, (f, e) => f.Internet.Email(e.FirstName))
                .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber("0#########"))
                .RuleFor(e => e.JobTitle, f => f.Name.JobTitle())
                .RuleFor(e => e.CompanyRegistrationNumber, f => f.Random.String2(10, "0123456789"))
                .RuleFor(e => e.TradingName, f => f.Company.CompanyName())
                .RuleFor(e => e.RegisteredBusinessName, (f, e) => e.TradingName + " " + f.Company.CompanySuffix())
                .RuleFor(e => e.RegisteredAddress, f => f.Address.FullAddress())
                .RuleFor(e => e.BusinessTypeId, f => f.PickRandom(businessTypes).Id)
                .RuleFor(e => e.EmployerTypeId, f => f.PickRandom(employerTypes).Id)
                .RuleFor(e => e.EmployerStatusId, f => f.PickRandom(employerStatuses).Id)
                .RuleFor(e => e.JobPosts, (_, e) => { return GetJobPosts(e.Id); });
        }

        private Faker<JobPost> GetJobPostGenerator(Guid empId)
        {
            var deps = _lookupRepository.GetDepartmentWithFaculty();
            var postStatus = _context.JobPostStatuses.ToList();
            var jobTypes = _context.JobTypes.ToList();
            var weekHours = _context.WeekHours.ToList();
            return new Faker<JobPost>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.EmployerId, _ => empId)
                .RuleFor(p => p.Department, f => f.PickRandom(deps).Name)
                .RuleFor(p => p.JobTitle, f => f.Name.JobTitle())
                .RuleFor(p => p.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(p => p.Location, f => f.Address.FullAddress())
                .RuleFor(p => p.KeyResponsibilities, f => f.Lorem.Lines(5, "|"))
                .RuleFor(p => p.HourlyRate, f => f.Finance.Amount(100, 350, 2))
                .RuleFor(p => p.ApplicationInstruction, f => f.Lorem.Lines(2, "|"))
                .RuleFor(p => p.MinimumRequirements, f => f.Lorem.Lines(3, "|"))
                .RuleFor(p => p.JobPostStatusId, f => f.PickRandom(postStatus).Id)
                .RuleFor(p => p.IsApproved, (f, p) => p.JobPostStatusId == 2 ? true : false)
                .RuleFor(p => p.ApproversComment, (f, p) => p.JobPostStatusId != 2 ? null : f.Lorem.Text().OrNull(f, 0.2f))
                .RuleFor(p => p.StartDate, f => f.Date.Future())
                .RuleFor(p => p.EndDate, (f, p) => f.Date.Between(p.StartDate, p.StartDate.AddYears(3)))
                .RuleFor(p => p.ClosingDate, (f, p) => f.Date.Between(DateTime.Now, p.StartDate))
                .RuleFor(p => p.ContactName, f => f.Name.FullName())
                .RuleFor(p => p.ContactEmail, (f, p) => f.Internet.Email(p.ContactName))
                .RuleFor(p => p.ContactNumber, f => f.Phone.PhoneNumber("0#########"))
                .RuleFor(p => p.JobTypeId, f => f.PickRandom(jobTypes).Id)
                .RuleFor(p => p.WeekHourId, (f, p) => p.JobTypeId == 2 ? 1 : f.PickRandom(weekHours).Id)
                .RuleFor(p => p.LimitedToSA, f => f.Random.Bool())
                .RuleFor(p => p.LimitedTo1stYear, f => f.Random.Bool())
                .RuleFor(p => p.LimitedTo2ndYear, f => f.Random.Bool())
                .RuleFor(p => p.LimitedTo3rdYear, f => f.Random.Bool())
                .RuleFor(p => p.LimitedToHonours, f => f.Random.Bool())
                .RuleFor(p => p.LimitedToGraduate, f => f.Random.Bool())
                .RuleFor(p => p.LimitedToMasters, f => f.Random.Bool())
                .RuleFor(p => p.LimitedToPhd, f => f.Random.Bool())
                .RuleFor(p => p.LimitedToPostdoc, f => f.Random.Bool())
                .RuleFor(p => p.LimitedToDepartment, f => f.Random.Bool())
                .RuleFor(p => p.LimitedToFaculty, f => f.Random.Bool());
        }

        private Faker<RegisterDto> GetStudentGenerator()
        {
            var deps = _lookupRepository.GetDepartmentWithFaculty();
            var driversLicense = _context.DriversLicenses.ToList();
            var gender = _context.Genders.ToList();
            var race = _context.Races.ToList();
            var nationality = _context.Nationalities.ToList();
            var yearOfStudy = _context.YearOfStudy.ToList();
            return new Faker<RegisterDto>()
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Email, (f,s) => f.Internet.Email(s.FirstName))
                .RuleFor(s => s.Password, (f,s) => f.Internet.Email(s.FirstName) + "A1!")
                .RuleFor(s => s.PhoneNumber, f => f.Phone.PhoneNumber("0#########"))
                .RuleFor(s => s.IdNumber, f => f.Random.String2(13, "012345689"))
                .RuleFor(s => s.Address, f => f.Address.FullAddress())
                .RuleFor(s => s.CareerObjective, f => f.Company.Bs())
                .RuleFor(s => s.Skills, f => f.Lorem.Lines(5, "|"))
                .RuleFor(s => s.Achievements, f => f.Lorem.Lines(3, "|"))
                .RuleFor(s => s.Interests, f => f.Lorem.Lines(4, "|"))
                .RuleFor(p => p.DepartmentId, f => f.PickRandom(deps).Id)
                .RuleFor(p => p.DriversLicenseId, f => f.PickRandom(driversLicense).Id)
                .RuleFor(p => p.GenderId, f => f.PickRandom(gender).Id)
                .RuleFor(p => p.RaceId, f => f.PickRandom(race).Id)
                .RuleFor(p => p.NationalityId, f => f.PickRandom(nationality).Id)
                .RuleFor(p => p.YearOfStudyId, f => f.PickRandom(yearOfStudy).Id);
        }

        private List<Employer> fakeEmployers = new();
        private List<JobPost> fakeJobPosts = new();
        public List<RegisterDto> fakeStudents = new();

        private List<JobPost> GetJobPosts(Guid empId)
        {
            var postGen = GetJobPostGenerator(empId);
            var posts = postGen.Generate(10);
            fakeJobPosts.AddRange(posts);
            return posts;
        }

        public async void GenerateFakerData()
        {
            //employers and job posts
            var empGen = GetEmployerGenerator();
            var employers = empGen.Generate(10);
            fakeEmployers.AddRange(employers);

            foreach (var emp in fakeEmployers)
                if (!_context.Employers.Any(e => e.Id == emp.Id))
                    _context.Employers.Add(emp);

            foreach (var post in fakeJobPosts)
                if (!_context.JobPosts.Any(p => p.Id == post.Id))
                    _context.JobPosts.Add(post);

            //students
            var studentGen = GetStudentGenerator();
            var students = studentGen.Generate(20);
            fakeStudents.AddRange(students);
            

            _context.SaveChanges();
        }

    }
}
