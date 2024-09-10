using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models
{
    public class Review
    {
        public int Id { get; set; }
        required public Post Post { get; init; }
        required public User Reviewer { get; init; }
        required public string Role { get; init; }
        required public string Body { get; set; }
        public int Rating { get; set; }
    }
}