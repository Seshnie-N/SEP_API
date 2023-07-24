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
            return _context.JobPosts.Include(p => p.JobType)
                .Include(p => p.Applications)
                .Include(p => p.WeekHour)
                .Include(p => p.JobPostStatus)
                .Include(p => p.Employer)
                .ToList();
        }

        public JobPost GetJobPost(int postId)
        {
            return _context.JobPosts.Include(p => p.JobType)
                .Include(p => p.Applications)
                .Include(p => p.WeekHour)
                .Include(p => p.JobPostStatus)
                .Include(p => p.Employer)
                .Where(p => p.Id == postId)
                .FirstOrDefault();
        }

        public bool JobPostExists(int postId)
        {
            return _context.JobPosts.Any(p => p.Id == postId);
        }
    }
}
