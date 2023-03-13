using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.Common.Mappings;
using DoctorCounseloing.Application.SchduleSlots.Query.GetAllDoctorSchduleSlotsCommand;
using DoctorCounseloing.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsQuery
{
    public record GetAllDoctorsQuery(int pageIndex = 0, int pageSize = 10) : IRequest<Result<PaginatedList<GetAllDoctorsQueryDto>>>;
    public class GetAllDoctorsQueryHandelar : IRequestHandler<GetAllDoctorsQuery, Result<PaginatedList<GetAllDoctorsQueryDto>>>
    {
        private readonly IDoctorRepositry _doctorrepo;
        private readonly IMapper _mapper;
        public GetAllDoctorsQueryHandelar(IDoctorRepositry doctorrepo, IMapper mapper)
        {
            _doctorrepo = doctorrepo;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedList<GetAllDoctorsQueryDto>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var noteList = _doctorrepo.GetAllDoctors().Result;
            var paginatedList = await noteList
                .ProjectTo<GetAllDoctorsQueryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.pageIndex, request.pageSize);
            return Result<PaginatedList<GetAllDoctorsQueryDto>>.Success(paginatedList);
        }

    }
}
