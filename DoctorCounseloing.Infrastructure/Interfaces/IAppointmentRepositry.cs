using DoctorCounseloing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.Interfaces
{
    public interface IAppointmentRepositry
    {
        Task<IQueryable<Appointment>> GetAllDoctorAppointment(Guid doctorId);
        Task<IQueryable<Appointment>> GetAllPatientAppointment(Guid patientId);
        Task<bool> InsertAsync(Appointment obj);

    }
}
