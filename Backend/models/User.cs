using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.models
{
    public class User
    {
        
        public int Id;
        public string Name  {get; set;}
        public List<Review> Reviews {get; } = new();
        
    }
}