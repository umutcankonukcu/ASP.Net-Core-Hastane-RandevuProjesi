using HastaneProjesi.Models;
using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneProjesi.Controllers
{
	[Authorize(Roles = "admin")]
	public class PatientController : Controller
	{
			PatientRepository PatientRepository = new PatientRepository();


			public IActionResult Index()
			{

				return View(PatientRepository.PatientList());
			}
		/*
			[HttpGet]
			public IActionResult PatientAdd()
			{
				return View();
			}
			[HttpPost]
			public IActionResult PatientAdd(Patient p)
			{
			// if (!ModelState.IsValid)
			// {
			//   return View("ClinicAdd");
			//}
			PatientRepository.PatientAdd(p);
				return RedirectToAction("Index");
			}*/
			public IActionResult PatientGet(int id)
			{
				var x = PatientRepository.GetPatient(id);
				Patient ptn = new Patient()
				{	PatientID = x.PatientID,
					UserName = x.UserName,
					Age = x.Age,
					Mail = x.Mail
				};
				return View(ptn);
			}
		/*
			[HttpPost]
			public IActionResult PatientUpdate(Patient p)
			{
				var x = PatientRepository.GetPatient(p.PatientID);
				x.UserName = p.UserName;
				x.Age = p.Age;
				x.Mail = p.Mail;
				PatientRepository.PatientUpdate(x);
				return RedirectToAction("Index");
			}*/

			public IActionResult PatientDelete(int id)
			{
			PatientRepository.PatientDelete(new Patient { PatientID = id });
			return RedirectToAction("Index");
			}
	
	}
}
