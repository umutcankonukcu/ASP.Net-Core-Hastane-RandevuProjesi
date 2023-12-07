namespace HastaneProjesi.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set;}
        public string DoctorType { get; set;}
        public string DoctortDescription { get; set;}
        public string DoctorEmail { get; set; }
        public int ClinicID { get; set; }
        public virtual Clinic Clinic { get; set; }

        public List<Patient> Patients { get; set; }

    }
}
