using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models
{
    public class Review
    {
        required public User User {get; init;}
        required public string Body {get; set;}
        public int Rating {get; set;}
    }
}