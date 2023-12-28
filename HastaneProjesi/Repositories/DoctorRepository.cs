
using HastaneProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneProjesi.Repositories
{
    public class DoctorRepository
    {
		Context c = new Context();
		public List<Doctor> DoctorList()
        {
            return c.Doctors.ToList();
        }
        public void DoctorAdd(Doctor dr)
        {
            c.Doctors.Add(dr);
            c.SaveChanges();
        }
        public void DoctorDelete(Doctor dr)
        {
			c.Doctors.Remove(dr);
			c.SaveChanges();
        }
        public void DoctorUpdate(Doctor dr)
        {
			c.Doctors.Update(dr);
			c.SaveChanges();
        }
        public Doctor GetDoctor(Doctor dr)
        {
			return c.Doctors.Find(dr);
            
        }
        public List<Doctor> DoctorList(string dr)
        {
            return c.Doctors.Include(dr).ToList();
        }

        
    }
}
