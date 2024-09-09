using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Payment { get; set; }
        public string Location { get; set; }
        public DateTime Date;

        public bool Taken { get; set; }
        public bool Fulfilled { get; set; }
        public User Poster { get; init; }
        public User? Fulfiller { get; set; }


    }
}