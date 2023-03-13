using AutoMapper;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.SchduleSlots.Query.GetAllDoctorSchduleSlotsCommand;
using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Appointments.Query.GetDoctorDetailsQuery
{
    public class GetAlldoctorsAppointmentQueryDto : IMapFrom<Appointment>
    {
      public string titleAr { get; set; }
      public string titleEn { get; set; }
      public string patientName { get; set; }
      public DateTimeOffset appointmentDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Appointment, GetAlldoctorsAppointmentQueryDto>()
                .ForMember(a => a.titleAr, obj => obj.MapFrom(x => x.Title.DescriptionAr))
                .ForMember(a => a.titleEn, obj => obj.MapFrom(x => x.Title.DescriptionEn))
                .ForMember(a => a.titleEn, obj => obj.MapFrom(x => x.Title.DescriptionEn))
                .ForMember(a => a.patientName, obj => obj.MapFrom(x => x.Patient.Name.DescriptionAr))
                .ForMember(a => a.appointmentDate, obj => obj.MapFrom(x => x.AppointmentTime));

        }
    }
}
