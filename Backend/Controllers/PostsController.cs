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
        if(user.ActivePost is not null) return BadRequest("Only one active post per user is permitted");

        Post post = (Post) (request, user);
        user.SetActivePost(post);
        _context.Posts.Add(post);

        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(CreatePost), new {id = post.Id}, post);
    }

    [HttpGet]
    public List<PostResponse> GetPosts()
    {
        return _context.Posts.Select(post => (PostResponse) post).ToList();
    }


}
