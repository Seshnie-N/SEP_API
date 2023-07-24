using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IJobPostRepository
    {
        ICollection<JobPost> GetJobPosts(); //ICollection of JobPosts
        JobPost GetJobPost(int postId);
        bool JobPostExists(int postId);
    }
}
