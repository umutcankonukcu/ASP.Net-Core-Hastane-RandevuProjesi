using HastaneProjesi.Models;

namespace HastaneProjesi.Repositories
{
    public class ClinicRepository
    {
        Context c = new Context();
        public List<Clinic> ClinicList()
        {
            return c.Clinics.ToList();
        }
        public void ClinicAdd(Clinic cl)
        {
            c.Clinics.Add(cl);
            c.SaveChanges();
        }
        public void ClinicDelete(Clinic cl)
        {
            c.Clinics.Remove(cl);
            c.SaveChanges();
        }
        public void ClinicUpdate(Clinic cl)
        {
            c.Clinics.Update(cl);
            c.SaveChanges();
        }
        public Clinic GetClinic(int id)
        {
           return c.Clinics.Find(id);
        }
        
    }
}
