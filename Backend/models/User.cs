using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models;

public class User
{
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


