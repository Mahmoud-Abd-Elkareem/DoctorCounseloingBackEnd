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

            Doctor[] doctor =
            {
                    new Doctor("Ali", "Ali", "AliAliAliAliAliAliAli", "AliAliAliAliAliAliAli",clinic.Id),
                    new Doctor("Ahmed", "Ahmed", "AhmedAhmedAhmedAhmed", "AhmedAhmedAhmedAhmed",clinic.Id),
                    new Doctor("Khalid", "Khalid", "KhalidKhalidKhalidKhalid", "KhalidKhalidKhalidKhalid",clinic.Id),
                    new Doctor("Samy", "Samy", "SamySamySamySamySamy", "SamySamySamySamySamy", clinic.Id),
                    new Doctor("Anwar", "Anwar", "AnwarAnwarAnwarAnwar", "AnwarAnwarAnwarAnwarAnwar", clinic.Id)
            };


            dbContext.Doctors.AddRange(doctor);

            Patient[] patient =
            {
                new Patient("Ali", "Ali", new DateTime()),
                new Patient("Ahmed", "Ahmed", new DateTime()),
                new Patient("Khalid", "Khalid", new DateTime()),
                new Patient("Samy", "Samy", new DateTime()),
                new Patient("Anwar", "Anwar", new DateTime()),
             };
            dbContext.Patients.AddRange(patient);

            dbContext.SaveChanges();
        }
    }
}
