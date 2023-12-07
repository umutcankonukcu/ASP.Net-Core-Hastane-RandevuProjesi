namespace HastaneProjesi.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientNumber { get; set; }

        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
