using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly FoodBoxContext _context;

    public ReviewsController(FoodBoxContext context)
    {
        _context = context;
    }


}
