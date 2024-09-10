using Backend.data;
using Backend.models;
using Microsoft.AspNetCore.Mvc;

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
}
