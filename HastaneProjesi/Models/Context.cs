
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneProjesi.Models
{
	public class Context : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JCH2STL\\SQLEXPRESS; database=DbCoreHospital1; TrustServerCertificate=True; Trusted_Connection=true");
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; } 
        public DbSet<Patient> Patients { get; set; }
		public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
       
	}
}
