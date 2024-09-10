using System.ComponentModel.DataAnnotations;


namespace Backend.models;

public class User
{
    [Key]
    public int Id;
    required public string ClerkId { get; init; }
    required public string Name { get; set; }
    public List<Review> Reviews { get; } = [];
    public Post? ActivePost { get; private set; }
    public List<Post> PostHistory { get; } = [];


    public bool ArchiveActivePost()
    {
        if (ActivePost is not null)
        {
            PostHistory.Add(ActivePost);
            this.ActivePost = null;
            return true;
        }
        return false;
    }
    public bool SetActivePost(Post post)
    {
        if (ActivePost is null)
        {
            ActivePost = post;
            return true;
        }
        return false;
    }
}


