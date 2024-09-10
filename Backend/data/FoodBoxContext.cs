using Microsoft.EntityFrameworkCore;
using  Backend.models;

namespace Backend.data;
public class FoodBoxContext : DbContext
    {

        public DbSet<Post> Posts { get; set; } = default!;
        public DbSet<User> Users {get; set;} = default!;
        public DbSet<Review> Reviews {get; set;} = default!;


        public FoodBoxContext(DbContextOptions<FoodBoxContext> options) : base(options)
        {
        }
    }