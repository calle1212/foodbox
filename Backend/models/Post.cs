using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.models;

public class Post
{
    [Key]
    public int Id { get; set; }
    required public string Title { get; set; }
    required public string Description { get; set; }
    public int Payment { get; set; }
    required public string Location { get; set; }
    public DateTime Date {get; set;}
    public int CreatorId { get; set; }
    required public User Creator { get; init; }
    public int FulfillerId { get; set; }

    public User? Fulfiller { get; private set; }

    public bool AddFulfiller(User fulfiller)
    {
        if (Fulfiller is null)
        {
            Fulfiller = fulfiller;
            return true;
        }
        return false;
    }

}


