using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure.Interfaces;
using DoctorCounseloing.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.Repositry
{
    public class PatientRepositry : IPatientRepositry
    {
        private DoctorCounseloingContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public PatientRepositry(DoctorCounseloingContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IQueryable<Patient>> GetAllPatients()
        {
            return _context.Patients.Include(doc => doc.Appointments).AsQueryable();
        }

        public async Task<List<KeyValueItem<Guid>>> GetAllPatientslookup()
        {
            return _context.Patients.Select(c => new KeyValueItem<Guid>(c.Id, c.Name.DescriptionAr)).ToList();
        }
    }
}
