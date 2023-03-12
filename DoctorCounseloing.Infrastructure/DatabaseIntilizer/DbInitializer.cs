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

            Doctor[] doctors =
            {
                    new Doctor("Ali", "Ali", "AliAliAliAliAliAliAli", "AliAliAliAliAliAliAli",clinic.Id),
                    new Doctor("Ahmed", "Ahmed", "AhmedAhmedAhmedAhmed", "AhmedAhmedAhmedAhmed",clinic.Id),
                    new Doctor("Khalid", "Khalid", "KhalidKhalidKhalidKhalid", "KhalidKhalidKhalidKhalid",clinic.Id),
                    new Doctor("Samy", "Samy", "SamySamySamySamySamy", "SamySamySamySamySamy", clinic.Id),
                    new Doctor("Anwar", "Anwar", "AnwarAnwarAnwarAnwar", "AnwarAnwarAnwarAnwarAnwar", clinic.Id)
            };


            dbContext.Doctors.AddRange(doctors);

            Patient[] patient =
            {
                new Patient("Ali", "Ali", new DateTime()),
                new Patient("Ahmed", "Ahmed", new DateTime()),
                new Patient("Khalid", "Khalid", new DateTime()),
                new Patient("Samy", "Samy", new DateTime()),
                new Patient("Anwar", "Anwar", new DateTime()),
             };

            foreach (var doctor in doctors)
            {
                SchduleSLot[] slots =
                {
                    new SchduleSLot(0,1,doctor.Id),
                    new SchduleSLot(0,2,doctor.Id),
                    new SchduleSLot(0,3,doctor.Id),
                    new SchduleSLot(0,4,doctor.Id),
                    new SchduleSLot(0,5,doctor.Id),
                    new SchduleSLot(0,6,doctor.Id),
                    new SchduleSLot(0,7,doctor.Id),
                    new SchduleSLot(1,1,doctor.Id),
                    new SchduleSLot(1,2,doctor.Id),
                    new SchduleSLot(1,3,doctor.Id),
                    new SchduleSLot(2,1,doctor.Id),
                    new SchduleSLot(2,2,doctor.Id),
                    new SchduleSLot(2,3,doctor.Id),
                    new SchduleSLot(2,4,doctor.Id),
                    new SchduleSLot(2,5,doctor.Id),
                    new SchduleSLot(2,6,doctor.Id),
                    new SchduleSLot(3,1,doctor.Id),
                    new SchduleSLot(3,2,doctor.Id)
                };
                dbContext.SchduleSLots.AddRange(slots);
            }
            dbContext.Patients.AddRange(patient);

            dbContext.SaveChanges();
        }
    }
}
