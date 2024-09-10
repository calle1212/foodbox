using System.ComponentModel.DataAnnotations;


namespace Backend.models;

public class Post
{
    [Key]
    public int Id {get; set;}
    required public string Title { get; set; }
    required public string Description { get; set; }
    public int Payment { get; set; }
    required public string Location { get; set; }
    public DateTime Date;
    required public User Creator { get; init; }
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


