using Backend.models;

namespace Backend.DTO;
public record PostResponse(string Title, string Description, int Payment, string Location, DateTime Date, string CreatorClerkId, string? FulfillerClerkId)
{
    public static implicit operator PostResponse(Post post)
    {
        if (post.Fulfiller is not null)
        {
            return new PostResponse(
                post.Title,
                post.Description,
                post.Payment,
                post.Location,
                post.Date,
                post.Creator!.ClerkId,
                post.Fulfiller.ClerkId
                );
        }
        return new PostResponse(
                post.Title,
                post.Description,
                post.Payment,
                post.Location,
                post.Date,
                post.Creator!.ClerkId,
                ""
        );

    }
}
