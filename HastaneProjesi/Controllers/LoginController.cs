using HastaneProjesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HastaneProjesi.Controllers
{
    public class LoginController : Controller
    {
        
        Context c = new Context();
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            var informations = c.Admins.FirstOrDefault
                (x=>x.UserName == p.UserName && x.Password==p.Password);

            if (informations != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserName),
                };
                var useridentity = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Clinic");
            }
            return View();
        }

    
    }
}
