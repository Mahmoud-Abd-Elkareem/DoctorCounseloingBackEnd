using DoctorCounseloing.Application;
using DoctorCounseloing.Application.Appointments.Command.CreateAppointmentCommand;
using DoctorCounseloing.Application.Appointments.Query.GetAllPatientAppointmentQuery;
using DoctorCounseloing.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DoctorCounseloing.API.Controllers
{
     [Route("api/v1/[controller]")]
     [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<PaginatedList<GetAllPatientAppointmentQueryDto>>), (int)HttpStatusCode.OK)]
        public async Task<Result<PaginatedList<GetAllPatientAppointmentQueryDto>>> GetAll([FromQuery] GetAllPatientAppointmentQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Result<string>> Create(CreateAppointmentCommand command)
        {

            return await _mediator.Send(command);
        }


    }
}
