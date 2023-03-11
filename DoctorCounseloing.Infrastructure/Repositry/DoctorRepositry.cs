using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.Repositry
{
    public class DoctorRepositry : IRepository<Doctor>
    {
        private DoctorCounseloingContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public DoctorRepositry(DoctorCounseloingContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Doctor doctor = await GetByIdAsync(id);
            if (doctor == null) return false;
            _context.Remove<Doctor>(doctor);
            return _context.SaveChanges() == 1 ? true : false;
        }


        public async Task<IQueryable<Doctor>> GetAllAsync()
        {
            return _context.Doctors.AsQueryable();
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await _context.Doctors.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> InsertAsync(Doctor obj)
        {
            obj.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name ?? "DoctorCounseloingUser";
            obj.Created = DateTime.UtcNow;
            _context.Doctors.AddAsync(obj);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public async Task<bool> UpdateAsync(Doctor obj)
        {
            obj.LastModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name ?? "DoctorCounseloingUser";
            obj.LastModified = DateTime.UtcNow;
            _context.Entry(obj).State = EntityState.Modified;
            return _context.SaveChanges() == 1 ? true : false;
        }







    }
}
