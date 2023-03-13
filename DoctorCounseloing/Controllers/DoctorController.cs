using DoctorCounseloing.Application.Appointments.Query.GetAllPatientAppointmentQuery;
using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsQuery;
using DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsLookupQuery;
using DoctorCounseloing.Infrastructure.Models;
using DoctorCounseloing.Application.Doctors.Query.GetAllPatientsLookupQuery;
using DoctorCounseloing.Application.Doctors.Query.GetDoctorDetailsQuery;

namespace DoctorCounseloing.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(Result<PaginatedList<GetAllDoctorsQueryDto>>), (int)HttpStatusCode.OK)]
        public async Task<Result<PaginatedList<GetAllDoctorsQueryDto>>> GetAll([FromQuery] GetAllDoctorsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("DoctorDetails")]
        [ProducesResponseType(typeof(Result<GetDoctorDetailsQueryDto>), (int)HttpStatusCode.OK)]
        public async Task<Result<GetDoctorDetailsQueryDto>> GetdoctorDetials([FromQuery] GetDoctorDetailsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("lookup")]
        [ProducesResponseType(typeof(Result<List<KeyValueItem<Guid>>>), (int)HttpStatusCode.OK)]
        public async Task<Result<List<KeyValueItem<Guid>>>> GetAlllookup()
        {
            var query = new GetAllDoctorsLookupQuery();
            return await _mediator.Send(query);
        }
    }
}
