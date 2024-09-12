using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.data;
using Backend.DTO;
using Backend.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly FoodBoxContext _context;

    public PostsController(FoodBoxContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePost(PostRequest request)
    {
        User? user =_context.Users.Include(user => user.ActivePost)
                                  .FirstOrDefault(user => user.ClerkId == request.CreatorClerkId);
        if(user is null) return NotFound("The user has not been created");
        if(user.ActivePost is not null) user.ActivePost.IsAborted = true;

        Post post = (Post) (request, user);
        
        user.ActivePost = post;
        _context.Posts.Add(post);

        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(CreatePost), new {id = post.Id}, post);
    }

    [HttpGet]
    public List<PostResponse> GetPosts()
    {
        return _context.Posts.Include(post => post.Creator).Select(post => (PostResponse) post).ToList();
    }

    [HttpPost("AcceptJob")]
    public async Task<IActionResult> AcceptJob(string fulfillerClerkId, int postId){
        Post? post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if(post == null) return NotFound("Post not found");

        User? user = await _context.Users.FirstOrDefaultAsync(u => u.ClerkId == fulfillerClerkId);
        if(user == null) return NotFound("The fulfiller user could not be found");

        bool ok =  post.AddFulfiller(user);
        if(!ok) return BadRequest("The job already has a fulfiller");
        user.AcceptedJobs.Add(post);
        await _context.SaveChangesAsync();
        return Ok();
        
    } 

    [HttpPut("FulfillJob")]
     public async Task<IActionResult> FulfillJob(string creatorClerkId, int postId){
        Post? post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if(post == null) return NotFound("Post not found");
        if(post.Fulfiller == null) BadRequest("No one has accepted this post");

        User? user = await _context.Users.FirstOrDefaultAsync(u => u.ClerkId == creatorClerkId);
        if(user == null) return NotFound("The creator user could not be found");

        post.IsFulfilled = true;
        user.ActivePost = null;
        user.PostHistory.Add(post);
        await _context.SaveChangesAsync();
        return Ok();
        
    } 


}
