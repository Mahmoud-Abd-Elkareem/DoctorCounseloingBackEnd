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

namespace DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsLookupQuery
{
    public record GetAllDoctorsLookupQuery() : IRequest<Result<List<KeyValueItem<Guid>>>>;
    public class GetAllDoctorsLookupQueryHandler : IRequestHandler<GetAllDoctorsLookupQuery, Result<List<KeyValueItem<Guid>>>>
    {
        private readonly IDoctorRepositry _doctorrepo;
        private readonly DoctorCounseloingContext _context;

        public GetAllDoctorsLookupQueryHandler(DoctorCounseloingContext context, IDoctorRepositry doctorrepo)
        {
            _context = context ;
            _doctorrepo = doctorrepo;
        }

        public async Task<Result<List<KeyValueItem<Guid>>>> Handle(GetAllDoctorsLookupQuery request, CancellationToken ct)
        {
            var query = await _doctorrepo.GetAllDoctorslookup();

            return Result<List<KeyValueItem<Guid>>>.Success(query);
        }
    }

}
