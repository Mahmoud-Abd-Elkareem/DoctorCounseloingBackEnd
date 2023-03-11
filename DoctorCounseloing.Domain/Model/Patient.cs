using DoctorCounseloing.Domain.Abstractions;
using DoctorCounseloing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Domain.Model
{
    public class Patient : AuditableEntity<Guid>
    {
        public DescriptionLocalized Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {

        }

        public Patient(string nameAr, string nameEn, DateTime dateTime) : base()
        {
            Name = new DescriptionLocalized(nameAr, nameEn);
            BirthDate = dateTime;
            Created = DateTime.Now;
            CreatedBy = "DoctorCounseloingUser";
        }

    }
}
