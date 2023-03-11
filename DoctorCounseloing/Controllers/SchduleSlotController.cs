using DoctorCounseloing.Application.Appointments.Command.CreateAppointmentCommand;
using DoctorCounseloing.Application.Appointments.Query.GetAllPatientAppointmentQuery;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DoctorCounseloing.Application.SchduleSlots.Command.AddDoctorSchduleSlotsCommand;
using DoctorCounseloing.Application.SchduleSlots.Query.GetAllDoctorSchduleSlotsCommand;

namespace DoctorCounseloing.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchduleSlotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SchduleSlotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<PaginatedList<GetAllDoctorSchduleSlotsQueryDto>>), (int)HttpStatusCode.OK)]
        public async Task<Result<PaginatedList<GetAllDoctorSchduleSlotsQueryDto>>> GetAll([FromQuery] GetAllDoctorSchduleSlotsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Result<string>> Create(AddDoctorSchduleSlotsCommand command)
        {

            return await _mediator.Send(command);
        }




    }
}
