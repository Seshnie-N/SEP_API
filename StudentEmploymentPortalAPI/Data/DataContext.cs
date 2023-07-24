using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //Domain Model DbSets
        public DbSet<Student> Students { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<StudentApplication> Applications { get; set; }

        //Look-up DbSets
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<EmployerType> EmployerTypes { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<WeekHour> WeekHours { get; set; }
        public DbSet<YearOfStudy> YearOfStudy { get; set; }
        public DbSet<EmployerStatus> EmployerStatuses { get; set; }
        public DbSet<JobPostStatus> JobPostStatuses { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<DriversLicense> DriversLicenses { get; set; }
        public DbSet<Race> Races { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
