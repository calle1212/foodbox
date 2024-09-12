using System.ComponentModel.DataAnnotations;

namespace Backend.models;
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int CreatorId { get; set; }
        required public User Creator { get; init; }
        public int FulfillerId { get; set; }
        required public User Fulfiller { get; init; }
        required public string Body { get; set; }
        public int Rating { get; set; }
    }
