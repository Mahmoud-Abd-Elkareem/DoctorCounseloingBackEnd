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
    public class AppointmentRepositry : IAppointmentRepositry
    {
               private DoctorCounseloingContext _context;
               private IHttpContextAccessor _httpContextAccessor;

        public AppointmentRepositry(DoctorCounseloingContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;            
        }

        public async Task<IQueryable<Appointment>> GetAllDoctorAppointment(Guid doctorId)
        {
            var doctorAppoitments =  _context.Appointments.Where(x => x.DoctorId == doctorId).AsQueryable();
            return doctorAppoitments;

        }

        public async Task<IQueryable<Appointment>> GetAllPatientAppointment(Guid patientId)
        {
            var patientAppoitments = _context.Appointments.Where(x => x.PatientId == patientId).AsQueryable();
            return patientAppoitments;
        }

        public async Task<bool> InsertAsync(Appointment obj)
        {
            obj.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name ?? "DoctorCounseloingUser";
            obj.Created = DateTime.UtcNow;
            _context.Appointments.AddAsync(obj);
            return _context.SaveChanges() == 1 ? true : false;
        }


    }
}
