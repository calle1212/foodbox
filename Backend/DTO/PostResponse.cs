using Backend.models;

namespace Backend.DTO;
public record PostResponse(int Id, string Title, string Description, int Payment, string Location, DateTime Date, string CreatorClerkId, string CreatorName, string? FulfillerClerkId, bool IsFulfilled, string? ImageUrl, ReviewResponse? ReviewOnCreator, ReviewResponse? ReviewOnFulfiller )
{
    public static implicit operator PostResponse(Post post)
    {
        ReviewResponse? reviewOnCreator = null;
        if( post.ReviewOnCreator is not null) 
        {
            reviewOnCreator = (ReviewResponse) post.ReviewOnCreator;
        }
        ReviewResponse? reviewOnFulfiller = null;
        if( post.ReviewOnCreator is not null) 
        {
            reviewOnFulfiller = (ReviewResponse) post.ReviewOnCreator;
        }
        
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
                post.ImageUrl,
                reviewOnCreator,
                reviewOnFulfiller

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
                post.ImageUrl,
                reviewOnCreator,
                reviewOnFulfiller
        );

    }
}
