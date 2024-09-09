using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models;

public class Post
{
    required public string Title { get; set; }
    required public string Description { get; set; }
    public int Payment { get; set; }
    required public string Location { get; set; }
    public DateTime Date;
    required public User Creator { get; init; }
    public User? Fulfiller { get; private set; }

    public bool AddFulfiller(User fulfiller)
    {
        if(Fulfiller is null ) 
        {
            Fulfiller = fulfiller;
            return true;
        }
        return false;
    }

}


