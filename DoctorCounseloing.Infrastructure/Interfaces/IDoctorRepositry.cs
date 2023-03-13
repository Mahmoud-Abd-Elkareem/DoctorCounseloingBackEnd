using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.Interfaces
{
    public interface IDoctorRepositry
    {
        Task<IQueryable<Doctor>> GetAllDoctors();
        Task<List<KeyValueItem<Guid>>> GetAllDoctorslookup();
        Task<Doctor> GetDoctor(Guid doctorIdd);


    }
}
