using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.Appointments.Command.CreateAppointmentCommand
{
    public record CreateAppointmentCommand( string titleAr , string titleEn, DateTimeOffset appointmentdate , Guid patientId , Guid doctorId) : IRequest<Result<string>>;
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Result<string>>
    {
            private readonly IAppointmentRepositry _appointmentrepo;
            public CreateAppointmentCommandHandler(IAppointmentRepositry noterepo)
              {
                    _appointmentrepo = noterepo;
              }
        public async Task<Result<string>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {

            var checkAppointment =  _appointmentrepo.GetAllDoctorAppointment(request.doctorId)
                .ConfigureAwait(false)
                .GetAwaiter().GetResult().Any(app => app.AppointmentTime == request.appointmentdate);

            if (checkAppointment) return Result<string>.Failure(new string[] { "There is appointment at the same time" });

            var appointmentObj = Appointment.AddAppointment(request.titleAr, request.titleEn, request.appointmentdate, request.patientId,request.doctorId);
            if (await _appointmentrepo.InsertAsync(appointmentObj) is true)
            {
                return Result<string>.Success("Done Successfully");
            }
            else
            {
                return Result<string>.Failure(new string[] { "Operation Failed" });
            }
        }


    }
}
