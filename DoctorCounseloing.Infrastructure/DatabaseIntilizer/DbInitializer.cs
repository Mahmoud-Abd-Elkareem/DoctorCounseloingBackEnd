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
            new Clinic("عيادة الاجيال السعيدة", "Happy Generations Clinic", "عيادة متخصصة في جميع الامراض النفسية والعصبية والهضمية", "A clinic specialized in all mental, nervous and digestive diseases");
            dbContext.Clinics.Add(clinic) ;

            Doctor[] doctors =
            {
                    new Doctor("علي", "Ali", "دكتور امراض نسا ولادة", "Obstetrics gynecologist",clinic.Id),
                    new Doctor("احمد", "Ahmed", "دكتور امراض نفسية وعصبية", "Psychiatrist and neurologist",clinic.Id),
                    new Doctor("خالد", "Khalid", "دكتور جهاز هضمي ", "Gastroenterologist",clinic.Id),
                    new Doctor("سامي", "Samy", "دكتور تخسيس ومكافحة النحافة", "Doctor of weight loss and anti-thinness", clinic.Id),
                    new Doctor("أنور", "Anwar", "دكتور باطنة وجراحة", "Internal medicine and surgery", clinic.Id),
                    new Doctor("سعاد", "Soad", "دكتور طوارئ", "Emergency doctor", clinic.Id),
                    new Doctor("أمنية", "Omnya", "دكتور عام", "General practitioner", clinic.Id),
                    new Doctor("أية", "Aya", "دكتور استشاري", "Consulting medical doctor", clinic.Id)



            };


            dbContext.Doctors.AddRange(doctors);

            Patient[] patient =
            {
                new Patient("جلال", "Galal", new DateTime()),
                new Patient("يوسف", "Yousef", new DateTime()),
                new Patient("معاذ", "Moaz", new DateTime()),
                new Patient("فرج", "Farg", new DateTime()),
                new Patient("محمود", "Mahmoud", new DateTime()),
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
