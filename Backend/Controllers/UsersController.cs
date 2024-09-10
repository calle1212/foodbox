using Backend.data;
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


}
