using Microsoft.EntityFrameworkCore;

namespace HastaneProjesi.Models
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JCH2STL\\SQLEXPRESS; database=DbCoreHospital; TrustServerCertificate=True; Trusted_Connection=true");
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; } 
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
