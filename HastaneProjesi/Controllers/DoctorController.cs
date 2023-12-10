using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HastaneProjesi.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            DoctorRepository doctorRepository = new DoctorRepository();
            return View(doctorRepository.DoctorList());
        } 
    }
}
