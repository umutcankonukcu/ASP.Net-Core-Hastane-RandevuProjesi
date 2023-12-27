using HastaneProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneProjesi.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if(ModelState.IsValid) 
			{
				
			}
			return View(model);
		}

		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{

			}
			return View(model);
		}

		public IActionResult Profile()
		{
			return View();
		}
	}
}
