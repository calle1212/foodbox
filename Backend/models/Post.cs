using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models
{
    public class Post
    {
        required public string Title { get; set; }
        required  public string Description { get; set; }
        public int Payment { get; set; }
        required public string Location { get; set; }
        public DateTime Date;
        public bool IsTaken { get; set; } = false;
        required public User Creator { get; init; }
        public User? Fulfiller { get; set; }
    }
}