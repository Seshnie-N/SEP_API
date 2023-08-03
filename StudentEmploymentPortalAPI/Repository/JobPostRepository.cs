using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Repository
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStudentRepository _studentRepository;

        public JobPostRepository(DataContext context, UserManager<ApplicationUser> userManager, IStudentRepository studentRepository)
        {
            _context = context;
            _userManager = userManager;
            _studentRepository = studentRepository;
        }
        public async Task<ICollection<JobPost>> GetJobPostsAsync(string userId)
        {
            var student = _studentRepository.GetStudent(userId);
            var predicate = PredicateBuilder.New<JobPost>();
            predicate = predicate.And(p => p.IsApproved);
            predicate = predicate.And(p => p.JobPostStatus.Name.Equals("Approved"));
            //filter if student is not a south african citizen
            if (!student.IsSouthAfrican)
            {
                predicate = predicate.And(p => !p.LimitedToSA);
            }

            //filter by student's year of study
            int YearOfStudy = student.YearOfStudy.Id;
            switch (YearOfStudy)
            {
                case 1:
                    predicate = predicate.And(p => p.LimitedTo1stYear);
                    break;
                case 2:
                    predicate = predicate.And(p => p.LimitedTo2ndYear);
                    break;
                case 3:
                    predicate = predicate.And(p => p.LimitedTo3rdYear);
                    break;
                case 4:
                    predicate = predicate.And(p => p.LimitedToHonours);
                    break;
                case 5:
                    predicate = predicate.And(p => p.LimitedToGraduate);
                    break;
                case 6:
                    predicate = predicate.And(p => p.LimitedToMasters);
                    break;
                case 7:
                    predicate = predicate.And(p => p.LimitedToPhd);
                    break;
                case 8:
                    predicate = predicate.And(p => p.LimitedToPostdoc);
                    break;
            }
            predicate = predicate.Or(p => p.IsApproved && p.JobPostStatus.Name.Equals("Approved") && !p.LimitedTo1stYear && !p.LimitedTo2ndYear && !p.LimitedTo3rdYear && !p.LimitedToHonours && !p.LimitedToGraduate && !p.LimitedToMasters && !p.LimitedToPhd && !p.LimitedToPostdoc);

            var allPosts = _context.JobPosts.Include(p => p.JobType)
                .Include(p => p.Applications)
                .Include(p => p.WeekHour)
                .Include(p => p.JobPostStatus)
                .ToList();

            //filter out job posts that have already been applied to
            var postsAppliedToIds = _context.Applications.Where(a => a.StudentId == student.UserId).Select(a => a.JobPostId);

            var posts = _context.JobPosts.Where(predicate).Include(p => p.JobType)
                .Include(p => p.Applications)
                .Include(p => p.WeekHour)
                .Include(p => p.JobPostStatus)
                .Include(p => p.Employer)
                .ToList();
            posts = posts.Where(p => !postsAppliedToIds.Contains(p.Id)).ToList();

            return posts; 
        }

        public JobPost GetJobPost(Guid postId)
        {
            return _context.JobPosts.Include(p => p.JobType)
                .Include(p => p.Applications)
                .Include(p => p.WeekHour)
                .Include(p => p.JobPostStatus)
                .Include(p => p.Employer)
                .Where(p => p.Id == postId)
                .FirstOrDefault();
        }

        public bool JobPostExists(Guid postId)
        {
            return _context.JobPosts.Any(p => p.Id == postId);
        }
    }
}
