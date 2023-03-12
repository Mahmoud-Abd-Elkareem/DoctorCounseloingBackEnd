using DoctorCounseloing.Infrastructure;
using DoctorCounseloing.Infrastructure.Interfaces;
using DoctorCounseloing.Infrastructure.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Doctors.Query.GetAllPatientsLookupQuery
{
    public record GetAllPatientsLookupQuery() : IRequest<Result<List<KeyValueItem<Guid>>>>;
    public class GetAllPatientsLookupQueryHandler : IRequestHandler<GetAllPatientsLookupQuery, Result<List<KeyValueItem<Guid>>>>
    {
        private readonly IPatientRepositry _patientrepo;
        private readonly DoctorCounseloingContext _context;

        public GetAllPatientsLookupQueryHandler(DoctorCounseloingContext context, IPatientRepositry patientrepo)
        {
            _context = context;
            _patientrepo = patientrepo;
        }

        public async Task<Result<List<KeyValueItem<Guid>>>> Handle(GetAllPatientsLookupQuery request, CancellationToken ct)
        {
            var query = await _patientrepo.GetAllPatientslookup();

            return Result<List<KeyValueItem<Guid>>>.Success(query);
        }
    }

}


