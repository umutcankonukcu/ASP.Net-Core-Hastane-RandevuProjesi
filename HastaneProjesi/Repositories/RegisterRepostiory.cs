using HastaneProjesi.Models;
using Microsoft.EntityFrameworkCore;
namespace HastaneProjesi.Repositories
{
	public class RegisterRepostiory
	{
		Context c = new Context();
		public List<Patient> PatientList()
		{
			return c.Patients.ToList();
		}
		public void PatientAdd(Patient cl)
		{
			
			c.Patients.Add(cl);
			c.SaveChanges();
		}
	}
}
