using AutoMapper;
using AutoMapper.QueryableExtensions;
using Booking.Application.Common.Mappings;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.SchduleSlots.Query.GetAllDoctorSchduleSlotsCommand;
using DoctorCounseloing.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Appointments.Query.GetAllPatientAppointmentQuery
{
    public record GetAllPatientAppointmentQuery(Guid patientId, int pageIndex = 0, int pageSize = 10) : IRequest<Result<PaginatedList<GetAllPatientAppointmentQueryDto>>>;
    public class GetAllPatientAppointmentQueryHandelar : IRequestHandler<GetAllPatientAppointmentQuery, Result<PaginatedList<GetAllPatientAppointmentQueryDto>>>
    {
        private readonly IAppointmentRepositry _slotrepo;
        private readonly IMapper _mapper;
        public GetAllPatientAppointmentQueryHandelar(IAppointmentRepositry slotrepo, IMapper mapper)
        {
            _slotrepo = slotrepo;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedList<GetAllPatientAppointmentQueryDto>>> Handle(GetAllPatientAppointmentQuery request, CancellationToken cancellationToken)
        {
            var noteList = _slotrepo.GetAllPatientAppointment(request.patientId).Result;
            var paginatedList = await noteList
                .ProjectTo<GetAllPatientAppointmentQueryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.pageIndex, request.pageSize);
            return Result<PaginatedList<GetAllPatientAppointmentQueryDto>>.Success(paginatedList);
        }
    }
}
