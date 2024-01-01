using Microsoft.AspNetCore.Mvc;
using HastaneProjesi.Models;

namespace HastaneProjesi.Controllers
{  
    [ApiController]
    [Route("Admin")]
    public class ApiController : Controller
    {
        private readonly Context _context;
        public ApiController(Context context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Admins.ToList());
        }
    }
}
