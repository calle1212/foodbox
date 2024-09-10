using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.data;
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


}
