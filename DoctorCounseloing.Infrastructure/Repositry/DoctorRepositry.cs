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
    public class DoctorRepositry : IDoctorRepositry
    {
        private DoctorCounseloingContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public DoctorRepositry(DoctorCounseloingContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IQueryable<Doctor>> GetAllDoctors()
        {
            return _context.Doctors.Include(doc=>doc.SchduleSLots).Include(doc=>doc.Appointments).AsQueryable();
        }

        public async Task<List<KeyValueItem<Guid>>> GetAllDoctorslookup()
        {
            return await _context.Doctors.Select(c => new KeyValueItem<Guid>(c.Id, c.Name.DescriptionAr)).ToListAsync();
        }

        public async Task<Doctor> GetDoctor(Guid doctorId)
        {
            return await _context.Doctors.Include(doc => doc.SchduleSLots).Include(doc => doc.Appointments).ThenInclude(app=>app.Patient).FirstOrDefaultAsync(doc => doc.Id == doctorId);
        }
    }
}
