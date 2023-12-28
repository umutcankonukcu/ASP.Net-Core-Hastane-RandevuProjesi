using HastaneProjesi.Models;
using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using X.PagedList;


namespace HastaneProjesi.Controllers
{
    [Authorize(Roles ="admin")]
    public class DoctorController : Controller
    {
        Context c = new Context();
        DoctorRepository doctorRepository = new DoctorRepository();
        public IActionResult Index(int page = 1)
        {

            return View(doctorRepository.DoctorList("Clinic").ToPagedList(page, 5));
        }
        [HttpGet]
        public IActionResult DoctorAdd()
        {
            List<SelectListItem> values = (from x in c.Clinics.ToList().Where(x => x.Status == true)
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
            /*  if(!ModelState.IsValid)
               {
                   return View("DoctorAdd");

               } */

            doctorRepository.DoctorAdd(p);
            return RedirectToAction("Index");

        }

        public IActionResult DoctorDelete(int id)
        {
            doctorRepository.DoctorDelete(new Doctor { DoctorID = id });
            return RedirectToAction("Index");
        }

        /* public IActionResult DoctorGet(int id)
          {
              var x = doctorRepository.GetDoctor(id);
              Doctor d = new Doctor()
              {
                 ClinicID = x.ClinicID,
                 DoctorName = x.DoctorName,
                 DoctorDescription = x.DoctorDescription,
                 DoctorType = x.DoctorType,
                 DoctorEmail = x.DoctorEmail,

              };
              return View(d);
          } */
    }
		
}       


