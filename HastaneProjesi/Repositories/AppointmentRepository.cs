using HastaneProjesi.Models;

namespace HastaneProjesi.Repositories
{
    public class AppointmentRepository
    {
        Context c = new Context();
        public List<Appointment> AppointmentList()
        {
            return c.Appointments.ToList();
        }
        public void AppointmentAdd(Appointment cl)
        {

            c.Appointments.Add(cl);
            c.SaveChanges();
        }

        public void AppointmentDelete(Appointment cl)
        {
            c.Appointments.Remove(cl);
            c.SaveChanges();
        }
        public void AppointmentUpdate(Appointment cl)
        {
            c.Appointments.Update(cl);
            c.SaveChanges();
        }
        public Appointment GetAppointment(int id)
        {
            return c.Appointments.Find(id);
        }

    }
}
