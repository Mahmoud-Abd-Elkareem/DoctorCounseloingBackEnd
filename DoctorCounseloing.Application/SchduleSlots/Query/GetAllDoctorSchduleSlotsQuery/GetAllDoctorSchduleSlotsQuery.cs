using AutoMapper;
using AutoMapper.QueryableExtensions;
using Booking.Application.Common.Mappings;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.SchduleSlots.Query.GetAllDoctorSchduleSlotsCommand
{
    public record GetAllDoctorSchduleSlotsQuery(Guid doctorId , int pageIndex = 0, int pageSize = 10) : IRequest<Result<PaginatedList<GetAllDoctorSchduleSlotsQueryDto>>>;
    public class GetAllDoctorSchduleSlotsQueryHandelar : IRequestHandler<GetAllDoctorSchduleSlotsQuery, Result<PaginatedList<GetAllDoctorSchduleSlotsQueryDto>>>
    {
        private readonly ISchduleSlotRepositry _apprepo;
        private readonly IMapper _mapper;
        public GetAllDoctorSchduleSlotsQueryHandelar(ISchduleSlotRepositry apprepo, IMapper mapper)
        {
            _apprepo = apprepo;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedList<GetAllDoctorSchduleSlotsQueryDto>>> Handle(GetAllDoctorSchduleSlotsQuery request, CancellationToken cancellationToken)
        {
            var noteList = _apprepo.GetAllDoctorSchduleSlots(request.doctorId).Result;
            var paginatedList = await noteList
                .ProjectTo<GetAllDoctorSchduleSlotsQueryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.pageIndex, request.pageSize);
            return Result<PaginatedList<GetAllDoctorSchduleSlotsQueryDto>>.Success(paginatedList);
        }

    }


}
