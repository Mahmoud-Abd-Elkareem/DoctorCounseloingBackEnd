using AutoMapper;
using DoctorCounseloing.Application.Appointments.Query.GetDoctorDetailsQuery;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsQuery;
using DoctorCounseloing.Application.SchduleSlots.Query.GetDoctorDetailsQuery;
using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Doctors.Query.GetDoctorDetailsQuery
{
    public class GetDoctorDetailsQueryDto : IMapFrom<Doctor>
    {
        public string DoctorNameAr { get; set; }
        public string DoctorNameEn { get; set; }
        public string DoctorDescAr { get; set; }
        public string DoctorDescEn { get; set; }
        public List<DoctorSchduleSlotsQueryDto> SchduleSlots { get; set; }
        public List<GetAlldoctorsAppointmentQueryDto> appointments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Doctor, GetDoctorDetailsQueryDto>()
                .ForMember(a => a.DoctorNameAr, obj => obj.MapFrom(x => x.Name.DescriptionAr))
                .ForMember(a => a.DoctorNameEn, obj => obj.MapFrom(x => x.Name.DescriptionEn))
                .ForMember(a => a.DoctorDescAr, obj => obj.MapFrom(x => x.Description.DescriptionAr))
                .ForMember(a => a.DoctorDescEn, obj => obj.MapFrom(x => x.Description.DescriptionEn))
                .ForMember(a => a.SchduleSlots, obj => obj.MapFrom(x => x.SchduleSLots))
                .ForMember(a => a.appointments, obj => obj.MapFrom(x => x.Appointments));
        }
    }
}
