using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IJobPostRepository
    {
        JobPost GetJobPost(int postId);
        bool JobPostExists(int postId);
        Task<ICollection<JobPost>> GetJobPostsAsync(string userId);
    }
}
