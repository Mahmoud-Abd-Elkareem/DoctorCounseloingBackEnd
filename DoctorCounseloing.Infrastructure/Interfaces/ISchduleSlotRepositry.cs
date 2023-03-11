using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.Interfaces
{
    public interface ISchduleSlotRepositry
    {
        Task<IQueryable<SchduleSLot>> GetAllDoctorSchduleSlots(Guid doctorId);
        Task<bool> AddDoctorSchduleSlotsAsync(Guid doctorId , List<SchduleSLot> doctorSchduleSlots);
    }
}
