using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.DTO;
using Microsoft.AspNetCore.Components.Web;


namespace Backend.models;
public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    public int Payment { get; set; }

    [Required]
    public string Location { get; set; }

    public DateTime Date { get; set; }
    public string? ImageUrl {get; set;}
    public int? CreatorId { get; set; }
    public User? Creator { get; set; }
    public bool IsFulfilled {get; set;} = false; 
    public int? FulfillerId { get; set; }
    public User? Fulfiller { get; private set; }
    public Review? ReviewOnCreator {get; set;}
    public Review? ReviewOnFulfiller {get; set;}

    // Parameterless constructor for EF Core

    // Constructor for manual use (outside of EF Core)
    public Post(string title, string description, int payment, string location, DateTime date)
    {
        Title = title;
        Description = description;
        Payment = payment;
        Location = location;
        Date = date;
    }

    public Post(string title, string description, int payment, string location, DateTime date, User creator)
    {
        Title = title;
        Description = description;
        Payment = payment;
        Location = location;
        Date = date;
        Creator = creator;
        CreatorId = creator.Id;
    }

    public bool AddFulfiller(User fulfiller)
    {
        if (Fulfiller is null)
        {
            Fulfiller = fulfiller;
            FulfillerId = fulfiller.Id;
            return true;
        }
        return false;
    }

    public static implicit operator Post((PostRequest postReq, User creator) data)
    {
        return new Post(data.postReq.Title, data.postReq.Description, data.postReq.Payment, data.postReq.Location, data.postReq.Date, data.creator);
    }
}


