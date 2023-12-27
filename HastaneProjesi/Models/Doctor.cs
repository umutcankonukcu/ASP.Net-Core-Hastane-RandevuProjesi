using System.ComponentModel.DataAnnotations;

namespace HastaneProjesi.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required(ErrorMessage ="Doctor name not empty")]
        public string DoctorName { get; set;}
        
        [Required(ErrorMessage = "Doctor type not empty")]
        public string DoctorType { get; set;}
        
        public string DoctorDescription { get; set;}

        [Required(ErrorMessage = "Doctor mail not empty")]
        public string DoctorEmail { get; set; }
        
        [Required(ErrorMessage = "Clinic ID not empty")]
        public int ClinicID { get; set; }

        public virtual Clinic Clinic { get; set; }

      

    }
}
