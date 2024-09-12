using Backend.models;

namespace Backend.DTO;
public record UserResponse(int Id, string ClerkId,string Name,string? ImageUrl,Post? ActivePost, List<PostResponse> PostHistory,List<PostResponse> AcceptedJobs )
{
     public static implicit operator UserResponse(User user)
    {
        List<PostResponse> postHistory = user.PostHistory.Select(p => (PostResponse) p).ToList();
        List<PostResponse> acceptedJobs = user.AcceptedJobs.Select(p => (PostResponse) p).ToList();

        return new UserResponse(
        user.Id,
        user.ClerkId,
        user.Name,
        user.ImageUrl,
        user.ActivePost,
        postHistory,
        acceptedJobs
        );

    }
}