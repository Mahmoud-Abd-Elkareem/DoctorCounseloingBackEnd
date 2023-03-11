using DoctorCounseloing.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DoctorCounseloing.Infrastructure
{
    public class DoctorCounseloingContext : DbContext
    {
        public DoctorCounseloingContext(DbContextOptions<DoctorCounseloingContext> options) : base(options)
        {

        }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<SchduleSLot> SchduleSLots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
