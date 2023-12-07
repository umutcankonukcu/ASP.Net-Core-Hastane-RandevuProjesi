using HastaneProjesi.Models;

namespace HastaneProjesi.Repositories
{
    public class DoctorRepository
    {
        Context d = new Context();

        public List<Doctor> DoctorList()
        {
            return d.Doctors.ToList();
        }
        public void  DoctorAdd(Doctor dr)
        {
            d.Doctors.Add(dr);
            d.SaveChanges();
        }
        public void DoctorDelete(Doctor dr)
        {
            d.Doctors.Remove(dr);
            d.SaveChanges();
        }
        public void DoctorUpdate(Doctor dr)
        {
            d.Doctors.Update(dr);
            d.SaveChanges();
        }
        public void GetDoctor(Doctor dr)
        {
            d.Doctors.Find(dr);
            
        }
    }
}
