using AutoMapper;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsQuery;
using DoctorCounseloing.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Doctors.Query.GetDoctorDetailsQuery
{
    public record GetDoctorDetailsQuery(Guid doctorId) : IRequest<Result<GetDoctorDetailsQueryDto>>;
    public class GetDoctorDetailsQueryHandelar : IRequestHandler<GetDoctorDetailsQuery, Result<GetDoctorDetailsQueryDto>>
    {
        private readonly IDoctorRepositry _doctorrepo;
        private readonly IMapper _mapper;
        public GetDoctorDetailsQueryHandelar(IDoctorRepositry doctorrepo, IMapper mapper)
        {
            _doctorrepo = doctorrepo;
            _mapper = mapper;
        }
        public async Task<Result<GetDoctorDetailsQueryDto>> Handle(GetDoctorDetailsQuery request, CancellationToken cancellationToken)
        {
            var doctorObj = await  _doctorrepo.GetDoctor(request.doctorId);


            var doctorDto = _mapper.Map<GetDoctorDetailsQueryDto>(doctorObj);
            return Result<GetDoctorDetailsQueryDto>.Success(doctorDto);
        }

    }
}
