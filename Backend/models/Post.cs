using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.DTO;
using Microsoft.AspNetCore.Components.Web;


namespace Backend.models;

public class Post(string title, string description, int payment, string location, DateTime date)
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = title;
    [Required]
    public string Description { get; set; } = description;
    public int Payment { get; set; } = payment;
    [Required]
    public string Location { get; set; } = location;
    public DateTime Date { get; set; } = date;
    public int CreatorId { get; set; }
    public User? Creator { get; set; }
    public int FulfillerId { get; set; }
    public User? Fulfiller { get; private set; }

    public bool AddFulfiller(User fulfiller)
    {
        if (Fulfiller is null)
        {
            Fulfiller = fulfiller;
            return true;
        }
        return false;
    }

    public static implicit operator Post(PostRequest postReq)
    {
        return new Post(postReq.Title, postReq.Description, postReq.Payment, postReq.Location, postReq.Date);
    }

}


