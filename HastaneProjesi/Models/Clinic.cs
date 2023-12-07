namespace HastaneProjesi.Models
{
    public class Clinic
    {
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string ClinicDescription { get; set; }
        
        public List<Doctor> Doctors { get; set; }

    }
}
