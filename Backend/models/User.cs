using System.ComponentModel.DataAnnotations;
using Backend.DTO;


namespace Backend.models;

public class User
{
    [Key]
    public int Id {get; set;}
    required public string ClerkId { get; init; }
    required public string Name { get; set; }
    public string? ImageUrl {get; set;}
    public Post? ActivePost { get; set; }
    public List<Post> PostHistory { get; } = [];
    public List<Post> AcceptedJobs { get; } = [];


    // public bool ArchiveActivePost()
    // {
    //     if (ActivePost is not null)
    //     {
    //         PostHistory.Add(ActivePost);
    //         this.ActivePost = null;
    //         return true;
    //     }
    //     return false;
    // }
    public bool SetActivePost(Post post)
    {
        if (ActivePost is null)
        {
            ActivePost = post;
            return true;
        }
        return false;
    }

        public static implicit operator User(UserRequest userReq)
    {
        return new User{ Name = userReq.Name,
                         ClerkId = userReq.ClerkId
                        };
    }

}


