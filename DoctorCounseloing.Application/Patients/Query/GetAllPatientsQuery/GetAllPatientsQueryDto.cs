using AutoMapper;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.SchduleSlots.Query.GetAllPatientsQuery;
using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Doctors.Query.GetAllPatientsQuery
{
    public class GetAllPatientsQueryDto : IMapFrom<Patient>
    {
        public string DoctorNameAr { get; set; }
        public string DoctorNameEn { get; set; }
        public DateTime BirthDate { get; set; }
        public List<PatientAppointmentQueryDto> PatientAppointments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Patient, GetAllPatientsQueryDto>()
                .ForMember(a => a.DoctorNameAr, obj => obj.MapFrom(x => x.Name.DescriptionAr))
                .ForMember(a => a.DoctorNameEn, obj => obj.MapFrom(x => x.Name.DescriptionEn))
                .ForMember(a => a.BirthDate, obj => obj.MapFrom(x => x.BirthDate))
                .ForMember(a => a.PatientAppointments, obj => obj.MapFrom(x => x.Appointments));

        }


    }
}
