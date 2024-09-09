using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models
{
    public class User
    {
        public int Id;
        required public string ClerkId {get; init;} 
        required public string Name { get; set; }
        public List<Review> Reviews { get; } = [];
        public Post? ActivePost {get; set;}
        public List<Post> PostHistory { get; } = [];
    }
}