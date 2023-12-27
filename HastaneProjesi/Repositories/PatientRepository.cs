using HastaneProjesi.Models;

namespace HastaneProjesi.Repositories
{
	public class PatientRepository
	{
		Context c = new Context();
		public List<Patient> PatientList()
		{
			return c.Patients.ToList();
		}
		
		public void PatientDelete(Patient cl)
		{
			c.Patients.Remove(cl);
			c.SaveChanges();
		}
	/*	public void PatientUpdate(Patient cl)
		{
			c.Patients.Update(cl);
			c.SaveChanges();
		}*/
		public Patient GetPatient(int id)
		{
			return c.Patients.Find(id);
		}

	}
}
