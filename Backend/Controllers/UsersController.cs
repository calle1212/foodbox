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
    public async Task<ActionResult> PostUser(UserRequest userReq)
    {

        if (_context.Users.FirstOrDefault(user => user.ClerkId == userReq.ClerkId) != null) return BadRequest("User already exists");
        User user = (User)userReq;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUser), new { id = user.ClerkId }, user);
    }

    [HttpGet("History")]
    public async Task<ActionResult<List<PostResponse>>> GetPostHistory(string ClerkId)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(user => user.ClerkId == ClerkId);
        if (user is not null) return user.PostHistory.Select(post => (PostResponse)post).ToList();
        return NotFound("User was not found");
    }

    [HttpGet("ActivePost")]
    public async Task<ActionResult<PostResponse>> GetActivePost(string ClerkId)
    {
        User? user = await _context.Users.Include(user => user.ActivePost).ThenInclude(post => post.Fulfiller)
                                         .FirstOrDefaultAsync(user => user.ClerkId == ClerkId);
        if (user == null) return NotFound("The User was not found");
        if (user.ActivePost == null) return NotFound("User does not have an active post");


        return (PostResponse)user.ActivePost;
    }

    [HttpGet]
    public async Task<ActionResult<UserResponse>> GetUser(string id)
    {
        User? user = await _context.Users.Include(user => user.ActivePost)
                                          .Include(user => user.PostHistory).ThenInclude(p => p.Fulfiller)
                                          //.Include(user => user.PostHistory).ThenInclude(p => p.Creator)
                                          //.Include(user => user.AcceptedJobs).ThenInclude(p => p.Fulfiller)
                                          .Include(user => user.AcceptedJobs).ThenInclude(p => p.Creator)
                                         .FirstOrDefaultAsync(user => user.ClerkId == id);
        if (user == null) return NotFound("The User was not found");
        return (UserResponse)user;
    }


    [HttpPatch("AbortActivePost")]
    public async Task<IActionResult> AbortActivePost(string creatorClerkId)
    {
        Post? post = await _context.Posts.Include(post => post.Creator)
                            .FirstOrDefaultAsync(post => post.Creator!.ClerkId == creatorClerkId);
        
        if(post == null) return NotFound("post could not be found");

        post.IsAborted = true;
        await _context.SaveChangesAsync();

        return Ok();
    }
}
