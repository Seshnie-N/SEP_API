using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IJobPostRepository
    {
        ICollection<JobPost> GetJobPosts();
        JobPost GetJobPost(int postId);
        bool JobPostExists(int postId);
    }
}
