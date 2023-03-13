using DoctorCounseloing.Domain.Abstractions;
using DoctorCounseloing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorCounseloing.Domain.Model
{
    public class Appointment : AuditableEntity<Guid>
    {
        public DescriptionLocalized Title { get; set; }
        public DateTimeOffset AppointmentTime { get; set; }
        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public Patient Patient { get; private set; }    
        public Doctor Doctor { get; private set; }

        public Appointment()
        {

        }

        private Appointment(string titleAr , string titleEn , DateTimeOffset appointmentTime , Guid patientId , Guid doctorId )
        {
            Title = new DescriptionLocalized(titleAr, titleEn);
            AppointmentTime = appointmentTime;
            PatientId = patientId;
            DoctorId = doctorId;
        }

        public static Appointment AddAppointment(string titleAr, string titleEn, DateTimeOffset appointmentTime, Guid patientId, Guid doctorId)
        {
            var appointment = new Appointment(titleAr, titleEn, appointmentTime, patientId , doctorId);
            return appointment;
        }

    }
}
