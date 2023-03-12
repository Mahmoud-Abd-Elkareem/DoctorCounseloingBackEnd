using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsLookupQuery;
using DoctorCounseloing.Application.Doctors.Query.GetAllDoctorsQuery;
using DoctorCounseloing.Application;
using DoctorCounseloing.Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DoctorCounseloing.Application.Doctors.Query.GetAllPatientsQuery;
using DoctorCounseloing.Application.Doctors.Query.GetAllPatientsLookupQuery;

namespace DoctorCounseloing.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(Result<PaginatedList<GetAllPatientsQueryDto>>), (int)HttpStatusCode.OK)]
        public async Task<Result<PaginatedList<GetAllPatientsQueryDto>>> GetAll([FromQuery] GetAllPatientsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("lookup")]
        [ProducesResponseType(typeof(Result<List<KeyValueItem<Guid>>>), (int)HttpStatusCode.OK)]
        public async Task<Result<List<KeyValueItem<Guid>>>> GetAlllookup()
        {
            var query = new GetAllPatientsLookupQuery();

            return await _mediator.Send(query);
        }
    }
}
