using Backend.models;

namespace Backend.DTO;
public record ReviewResponse(int Id, string CreatorClerkId, string FulfillerClerkId, string Body, int Rating)
{
    public static implicit operator ReviewResponse(Review review)
    {
            return new ReviewResponse(
                review.Id,
                review.Creator.ClerkId,
                review.Fulfiller.ClerkId,
                review.Body,
                review.Rating
                );
        
    }
}