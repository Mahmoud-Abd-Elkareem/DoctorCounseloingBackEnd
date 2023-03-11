using DoctorCounseloing.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.DatabaseIntilizer
{
    public class DbInitializer
    {

        internal static void Initialize(DoctorCounseloingContext dbContext, IConfiguration config)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Doctors.Any() && dbContext.Clinics.Any() && dbContext.Patients.Any()) return;
            var clinic =
            new Clinic("Ali", "Ali", "AliAliAliAliAliAliAli", "AliAliAliAliAliAliAli");
            dbContext.Clinics.Add(clinic) ;

            var doctor =
            new Doctor("Ali", "Ali", "AliAliAliAliAliAliAli", "AliAliAliAliAliAliAli", clinic.Id);


            dbContext.Doctors.Add(doctor);

            var patient =
                new Patient("Ali", "Ali", new DateTime());
            dbContext.Patients.Add(patient);

            dbContext.SaveChanges();
        }
    }
}
