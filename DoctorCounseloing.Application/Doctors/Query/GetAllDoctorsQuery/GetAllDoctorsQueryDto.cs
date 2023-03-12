using AutoMapper;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.SchduleSlots.Query.DoctorSchduleSlotsQueryDto;
using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsQuery
{
    public class GetAllDoctorsQueryDto : IMapFrom<Doctor>
    {
        public string DoctorNameAr { get; set; }
        public string DoctorNameEn { get; set; }
        public string DoctorDescAr { get; set; }
        public string DoctorDescEn { get; set; }
        public List<DoctorSchduleSlotsQueryDto> schduleSlots { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Doctor, GetAllDoctorsQueryDto>()
                .ForMember(a => a.DoctorNameAr, obj => obj.MapFrom(x => x.Name.DescriptionAr))
                .ForMember(a => a.DoctorNameEn, obj => obj.MapFrom(x => x.Name.DescriptionEn))
                .ForMember(a => a.DoctorDescAr, obj => obj.MapFrom(x => x.Description.DescriptionAr))
                .ForMember(a => a.DoctorDescEn, obj => obj.MapFrom(x => x.Description.DescriptionEn))
                .ForMember(a => a.schduleSlots, obj => obj.MapFrom(x => x.SchduleSLots));

        }


    }
}
