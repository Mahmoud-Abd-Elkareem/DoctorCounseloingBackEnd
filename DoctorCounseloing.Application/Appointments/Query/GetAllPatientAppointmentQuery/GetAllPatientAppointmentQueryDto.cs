using AutoMapper;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.SchduleSlots.Query.GetAllDoctorSchduleSlotsCommand;
using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Appointments.Query.GetAllPatientAppointmentQuery
{
    public class GetAllPatientAppointmentQueryDto : IMapFrom<Appointment>
    {
      public string titleAr { get; set; }
      public string titleEn { get; set; }
      public DateTimeOffset appointmentDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Appointment, GetAllPatientAppointmentQueryDto>()
                .ForMember(a => a.titleAr, obj => obj.MapFrom(x => x.Title.DescriptionAr))
                .ForMember(a => a.titleEn, obj => obj.MapFrom(x => x.Title.DescriptionEn))
                .ForMember(a => a.appointmentDate, obj => obj.MapFrom(x => x.AppointmentTime));

        }
    }
}
