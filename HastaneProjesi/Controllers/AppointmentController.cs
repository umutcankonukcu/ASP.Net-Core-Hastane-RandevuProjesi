using HastaneProjesi.Migrations;
using HastaneProjesi.Models;
using HastaneProjesi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HastaneProjesi.Controllers
{
    public class AppointmentController : Controller
    {
        Context c = new Context();

        AppointmentRepository appointmentRepository = new AppointmentRepository();

        [Authorize(Roles = "user,admin")]
        public IActionResult MyAppointments()

        {
            return View(appointmentRepository.AppointmentList());
        }

        [Authorize(Roles ="admin")]
        public IActionResult AllAppointments()

        {
            return View(appointmentRepository.AppointmentList());
        }

        public IActionResult AppointmentGet(int id)
        {
            var x = appointmentRepository.GetAppointment(id);
            Appointment cln = new Appointment()
            {
                UserName = x.UserName,
                ClinicID = x.ClinicID,
                DoctorID = x.DoctorID,
                SelectedDate = x.SelectedDate
            };
            return View(cln);
        }

        public IActionResult AppointmentUpdate(Appointment p)
        {
            var x = appointmentRepository.GetAppointment(p.AppointmentID);
            x.UserName = p.UserName;
            x.ClinicID = p.ClinicID;
            x.DoctorID = p.DoctorID;
            x.SelectedDate = p.SelectedDate;
            appointmentRepository.AppointmentUpdate(x);
            return RedirectToAction("Index", "Patient");
        }

        public IActionResult AppointmentDelete(int id)
        {
            var x = appointmentRepository.GetAppointment(id);
            appointmentRepository.AppointmentUpdate(x);
            return RedirectToAction("Index", "Patient");

        }



        [Authorize(Roles = "user,admin")]
        [HttpGet]
        public IActionResult MakeAnAppointment()
        {     
			List<Clinic> clinics = c.Clinics.ToList();
            ViewBag.ListClinics = new SelectList(clinics, "ClinicID", "ClinicName");

			return View();
        }
        [HttpPost]
        public IActionResult GetDoctorByClinic(int clinicID)
        {
            List<Doctor> doctors = new List<Doctor>();
            doctors = c.Doctors.Where(e => e.ClinicID == clinicID).ToList();
            SelectList DoctorList = new SelectList(doctors,"DoctorID","DoctorName");
            return Json(DoctorList);
        }
        [Authorize(Roles = "user,admin")]
        [HttpPost]
        public IActionResult MakeAnAppointment(Appointment p)
        {
           

            AppointmentRepository appointmentRepository = new AppointmentRepository();

            appointmentRepository.AppointmentAdd(p);
            return RedirectToAction("Index", "Home");
        }

        public string GetClinicName(int clinicID)
        {
           
            var clinic = c.Clinics.FirstOrDefault(c => c.ClinicID == clinicID);
            return clinic != null ? clinic.ClinicName : "N/A";
        }
    }
}
