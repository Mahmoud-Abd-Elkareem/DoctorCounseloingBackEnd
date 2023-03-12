using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.Interfaces
{
    public interface IPatientRepositry
    {
        Task<IQueryable<Patient>> GetAllPatients();
        Task<List<KeyValueItem<Guid>>> GetAllPatientslookup();

    }
}
