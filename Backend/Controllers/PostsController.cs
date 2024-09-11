using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.data;
using Backend.DTO;
using Backend.models;
using Microsoft.AspNetCore.Mvc;

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
        User? user =_context.Users.FirstOrDefault(user => user.ClerkId == request.CreatorClerkId);
        if(user is null) return BadRequest("The has not been created");

        Post post = (Post) request;
        post.Creator = user;
        _context.Posts.Add(post);

        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(CreatePost), new {id = post.Id}, post);
    }


}
