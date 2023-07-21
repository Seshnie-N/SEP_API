using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Repository
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly DataContext _context;

        public JobPostRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<JobPost> GetJobPosts()
        {
            return _context.JobPosts.Include(p => p.JobType).Include(p => p.Applications).Include(p => p.WeekHour).Include(p => p.ApplicationStatus).ToList();
        }
    }
}
