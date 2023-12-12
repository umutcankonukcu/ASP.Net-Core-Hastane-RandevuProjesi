using HastaneProjesi.Models;
using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HastaneProjesi.Controllers
{
    public class DoctorController : Controller
    {
        Context c = new Context();
        DoctorRepository doctorRepository = new DoctorRepository();
        public IActionResult Index()
        {
            
            return View(doctorRepository.DoctorList("Clinic"));
        }
        [HttpGet]
        public IActionResult DoctorAdd()
        {
            List<SelectListItem> values = (from x in c.Clinics.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ClinicName,
                                               Value = x.ClinicID.ToString(),
                                            }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult DoctorAdd(Doctor p)
        {
           // if(!ModelState.IsValid)
           // {
            //    return View("DoctorAdd");

            //}

            doctorRepository.DoctorAdd(p);
            return RedirectToAction("Index");
        }
    }
}
