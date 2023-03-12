using AutoMapper;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.SchduleSlots.Command.AddDoctorSchduleSlotsCommand;
using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.SchduleSlots.Query.GetAllPatientsQuery
{
    public class PatientAppointmentQueryDto : IMapFrom<Appointment>
    {
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }

        public DateTimeOffset AppointmentTime { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Appointment, PatientAppointmentQueryDto>()
                .ForMember(a => a.TitleAr, obj => obj.MapFrom(x => x.Title.DescriptionAr))
                .ForMember(a => a.TitleEn, obj => obj.MapFrom(x => x.Title.DescriptionEn))
                .ForMember(a => a.AppointmentTime, obj => obj.MapFrom(x => x.AppointmentTime));

        }
    }
}
