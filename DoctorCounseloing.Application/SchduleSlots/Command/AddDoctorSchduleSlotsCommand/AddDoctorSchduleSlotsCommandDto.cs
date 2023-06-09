﻿using AutoMapper;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.SchduleSlots.Command.AddDoctorSchduleSlotsCommand
{
    public class AddDoctorSchduleSlotsCommandDto : IMapFrom<SchduleSLot>
    {
        public int Day { get; set; }
        public int UTCHour { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SchduleSLot, AddDoctorSchduleSlotsCommandDto>()
                .ForMember(a => a.Day, obj => obj.MapFrom(x => x.day))
                .ForMember(a => a.UTCHour, obj => obj.MapFrom(x => x.UTCHour));

        }
    }
}
