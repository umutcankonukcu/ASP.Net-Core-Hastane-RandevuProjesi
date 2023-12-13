using HastaneProjesi.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace HastaneProjesi.Models
{
    public class Clinic
    {
        public int ClinicID { get; set; }

        [Required(ErrorMessage ="Clinic name not empty!!!")]
        public string ClinicName { get; set; }
        public string ClinicDescription { get; set; }  
        public bool Status { get; set; }
        public List<Doctor> Doctors { get; set; }

    }
}
