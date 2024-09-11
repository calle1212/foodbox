using Backend.models;

namespace Backend.DTO;
public record PostRequest(string Title, string Description, int Payment, string Location, DateTime Date, string CreatorClerkId)
{
   
}
