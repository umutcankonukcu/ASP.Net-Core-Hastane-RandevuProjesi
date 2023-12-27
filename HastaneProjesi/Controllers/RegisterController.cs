using HastaneProjesi.Models;
using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HastaneProjesi.Controllers
{
	public class RegisterController : Controller
	{
		RegisterRepostiory registerRepostiory = new RegisterRepostiory();

		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}
		[HttpPost]
		public IActionResult Index(Patient p)
		{
			// if (!ModelState.IsValid)
			// {
			//   return View("ClinicAdd");
			//}
			registerRepostiory.PatientAdd(p);
            return RedirectToAction("Index", "Login");
        }
	}
}
