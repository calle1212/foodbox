using Microsoft.EntityFrameworkCore;
using Backend.models;

namespace Backend.data;
public class FoodBoxContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Review> Reviews { get; set; }


    public FoodBoxContext(DbContextOptions<FoodBoxContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Creator) 
            .WithMany(u => u.PostHistory)
            .HasForeignKey(p => p.CreatorId) 
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Fulfiller) 
            .WithMany() 
            .HasForeignKey(p => p.FulfillerId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<User>()
            .HasOne(u => u.ActivePost)
            .WithOne() 
            .HasForeignKey<Post>(p => p.Id) 
            .OnDelete(DeleteBehavior.Restrict); 
    }
}