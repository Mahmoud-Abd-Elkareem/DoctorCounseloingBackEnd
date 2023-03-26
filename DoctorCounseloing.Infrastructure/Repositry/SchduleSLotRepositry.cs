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
    public class SchduleSLotRepositry : ISchduleSlotRepositry
    {
        private DoctorCounseloingContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public SchduleSLotRepositry(DoctorCounseloingContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddDoctorSchduleSlotsAsync(Guid doctorId, List<SchduleSLot> doctorSchduleSlots)
        {
            var schduleSLots = _context.SchduleSLots.Where(s => s.DoctorId == doctorId);
            if(schduleSLots != null)
            {
                schduleSLots.ExecuteDeleteAsync();
            }
            _context.SchduleSLots.AddRange(doctorSchduleSlots);
             return  _context.SaveChanges() == doctorSchduleSlots.Count ? true : false;
        }

        public async Task<IQueryable<SchduleSLot>> GetAllDoctorSchduleSlots(Guid doctorId)
        {
            return  _context.SchduleSLots.Where(slot => slot.DoctorId == doctorId).AsQueryable();
        }
    }
}
