using HastaneProjesi.Models;
using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HastaneProjesi.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> Login(Admin p,Patient m)
		{
			Context c = new Context();
			var datavalue = c.Admins.FirstOrDefault(x => x.UserName == p.UserName
			&& x.Password == p.Password);
			var datavalue1 = c.Patients.FirstOrDefault(x => x.UserName == m.UserName
			&& x.Password == m.Password);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.UserName),
					new Claim(ClaimTypes.Role, p.Role),
				};
				var useridentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				//HttpContext.Session.SetString("UserName", p.UserName);
				return RedirectToAction("Index", "Clinic");
			}
			else if (datavalue1 != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, m.UserName),
					new Claim(ClaimTypes.Role, m.Role),
				};
				var useridentity = new ClaimsIdentity(claims, "b");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				//HttpContext.Session.SetString("UserName", p.UserName);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return View();
			}

		}

		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(Patient p)
		{
			Context c = new Context();
			

			RegisterRepostiory registerRepostiory = new RegisterRepostiory();
			// if (!ModelState.IsValid)
			// {
			//   return View("ClinicAdd");
			//}
			registerRepostiory.PatientAdd(p);
			return RedirectToAction("Login", "Account");
		}

		public IActionResult LogOut()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}
	}
}
