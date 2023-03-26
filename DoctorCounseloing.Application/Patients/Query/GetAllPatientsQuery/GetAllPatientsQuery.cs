using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoctorCounseloing.Application.Common.Mappings;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.SchduleSlots.Query.GetAllDoctorSchduleSlotsCommand;
using DoctorCounseloing.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Doctors.Query.GetAllPatientsQuery
{
    public record GetAllPatientsQuery(int pageIndex = 0, int pageSize = 10) : IRequest<Result<PaginatedList<GetAllPatientsQueryDto>>>;
    public class GetAllPatientsQueryHandelar : IRequestHandler<GetAllPatientsQuery, Result<PaginatedList<GetAllPatientsQueryDto>>>
    {
        private readonly IPatientRepositry _patientrepo;
        private readonly IMapper _mapper;
        public GetAllPatientsQueryHandelar(IPatientRepositry patientrepo, IMapper mapper)
        {
            _patientrepo = patientrepo;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedList<GetAllPatientsQueryDto>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var noteList = await _patientrepo.GetAllPatients();
            var paginatedList = await noteList
                .ProjectTo<GetAllPatientsQueryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.pageIndex, request.pageSize);
            return Result<PaginatedList<GetAllPatientsQueryDto>>.Success(paginatedList);
        }

    }
}
