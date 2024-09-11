using Backend.data;
using Backend.DTO;
using Backend.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly FoodBoxContext _context;

    public UsersController(FoodBoxContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> PostUser([Bind("ClerkId,Name")] User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUser), new { id = user.ClerkId }, user);
    }

    [HttpGet("History")]
    public async Task<ActionResult<List<PostResponse>>> GetPostHistory(string ClerkId)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(user => user.ClerkId == ClerkId);
        if(user is not null) return user.PostHistory.Select(post => (PostResponse) post).ToList();
        return NotFound("User was not found");
    }

    [HttpGet]
    public async Task<ActionResult<PostResponse>> GetActivePost(string ClerkId)
    {
        User? user = await _context.Users.Include(user => user.ActivePost)
                                         .FirstOrDefaultAsync(user => user.ClerkId == ClerkId);
        if(user == null) return NotFound("The User was not found");
        if(user.ActivePost == null) return NotFound("User does not have an active post");
        return (PostResponse) user.ActivePost;
    }
}
