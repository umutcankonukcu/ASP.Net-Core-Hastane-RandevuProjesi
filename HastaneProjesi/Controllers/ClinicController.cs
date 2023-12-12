using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Mvc;
using HastaneProjesi.Models;
using Microsoft.Identity.Client;

namespace HastaneProjesi.Controllers
{
    public class ClinicController : Controller
    {
        ClinicRepository clinicRepository = new ClinicRepository();
        public IActionResult Index()
        {
            
            return View(clinicRepository.ClinicList());   
        }
        [HttpGet]
        public IActionResult ClinicAdd()
            {
                return View();
            }
        [HttpPost]
        public IActionResult ClinicAdd(Clinic p)
        {
           // if (!ModelState.IsValid)
           // {
             //   return View("ClinicAdd");
            //}
            clinicRepository.ClinicAdd(p);
            return RedirectToAction("Index");
        }

    }
}
