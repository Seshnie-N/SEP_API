using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IJobPostRepository
    {
        JobPost GetJobPost(Guid postId);
        bool JobPostExists(Guid postId);
        Task<ICollection<JobPost>> GetJobPostsAsync(string userId);
    }
}
