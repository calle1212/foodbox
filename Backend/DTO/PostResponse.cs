using Backend.models;

namespace Backend.DTO;
public record PostResponse(string Title, string Description, int Payment, string Location, DateTime Date, string CreatorClerkId, string? FulfillerClerkId, string? imageUrl)
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
                post.Fulfiller.ClerkId,
                post.ImageUrl
                );
        }
        return new PostResponse(
                post.Title,
                post.Description,
                post.Payment,
                post.Location,
                post.Date,
                post.Creator!.ClerkId,
                "",
                post.ImageUrl
        );

    }
}
