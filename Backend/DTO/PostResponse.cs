using Backend.models;

namespace Backend.DTO;
public record PostResponse(int Id, string Title, string Description, int Payment, string Location, DateTime Date, string CreatorClerkId, string CreatorName, string? FulfillerClerkId, bool IsFulfilled, string? ImageUrl)
{
    public static implicit operator PostResponse(Post post)
    {
        if (post.Fulfiller is not null)
        {
            return new PostResponse(
                post.Id,
                post.Title,
                post.Description,
                post.Payment,
                post.Location,
                post.Date,
                post.Creator!.ClerkId,
                post.Creator.Name,
                post.Fulfiller.ClerkId,
                post.IsFulfilled,
                post.ImageUrl
                );
        }
        return new PostResponse(
                post.Id,
                post.Title,
                post.Description,
                post.Payment,
                post.Location,
                post.Date,
                post.Creator!.ClerkId,
                post.Creator.Name,
                "",
                post.IsFulfilled,
                post.ImageUrl
        );

    }
}
