using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Mvc;
using HastaneProjesi.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace HastaneProjesi.Controllers
{
	
	[Authorize(Roles ="admin")]
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
        public IActionResult ClinicGet(int id)
        {
            var x = clinicRepository.GetClinic(id);
            Clinic cln = new Clinic()
            {
                ClinicName = x.ClinicName,
                ClinicDescription = x.ClinicDescription,
                ClinicID = x.ClinicID,     
                Status = x.Status
            };
            return View(cln);
        }
        [HttpPost]
        public IActionResult ClinicUpdate(Clinic p)
        {
            var x = clinicRepository.GetClinic(p.ClinicID);
            x.ClinicName = p.ClinicName;
            x.ClinicDescription = p.ClinicDescription;
            x.Status = p.Status;
            clinicRepository.ClinicUpdate(x);
            return RedirectToAction("Index");
        }
        
        public IActionResult ClinicDelete(int id)
        {
            var x = clinicRepository.GetClinic(id);
            x.Status = false;
            clinicRepository.ClinicUpdate(x);
            return RedirectToAction("Index");

        }
    }
}
