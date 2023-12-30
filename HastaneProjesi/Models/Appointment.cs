using System.ComponentModel.DataAnnotations;

namespace HastaneProjesi.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }


        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters")]
        public string UserName { get; set; } 


       
        [Required(ErrorMessage = "Clinic is required")]
        
        public string ClinicID { get; set; }

        [Required(ErrorMessage = "Doctor is required")]

        public string DoctorID { get; set; }


        [Required(ErrorMessage ="Date and Time is required")]
        public DateTime SelectedDate { get; set; }
        
    }
}
