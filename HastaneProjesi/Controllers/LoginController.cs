using HastaneProjesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HastaneProjesi.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(Admin p)
		{
			Context c = new Context();
			var datavalue = c.Admins.FirstOrDefault(x=>x.UserName == p.UserName 
			&& x.Password == p.Password);
			if (datavalue != null) 
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.UserName),
				};
				var useridentity = new ClaimsIdentity(claims,"a");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				//HttpContext.Session.SetString("UserName", p.UserName);
				return RedirectToAction("Index","Clinic");
			}
			
			else
			{
				return View();
			}
			
		}
	}
}
