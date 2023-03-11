using AutoMapper;
using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure.Interfaces;
using DoctorCounseloing.Infrastructure.Migrations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Application.SchduleSlots.Command.AddDoctorSchduleSlotsCommand
{
    public record AddDoctorSchduleSlotsCommand(Guid doctorId , List<AddDoctorSchduleSlotsCommandDto> doctorSchduleSlots) : IRequest<Result<string>>;
    public class AddDoctorSchduleSlotsCommandHandler : IRequestHandler<AddDoctorSchduleSlotsCommand, Result<string>>
    {
        private readonly ISchduleSlotRepositry _slotrepo;
        private readonly IMapper _mapper;

        public AddDoctorSchduleSlotsCommandHandler(ISchduleSlotRepositry slotrepo , IMapper mapper)
        {
            _slotrepo = slotrepo;
            _mapper = mapper;
        }
        public async Task<Result<string>> Handle(AddDoctorSchduleSlotsCommand request, CancellationToken cancellationToken)
        {
            var mappedSlots = request.doctorSchduleSlots.Select(dto => new SchduleSLot(dto.Day, dto.UTCHour, request.doctorId)).ToList();

            if (await _slotrepo.AddDoctorSchduleSlotsAsync(request.doctorId , mappedSlots) is true)
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
