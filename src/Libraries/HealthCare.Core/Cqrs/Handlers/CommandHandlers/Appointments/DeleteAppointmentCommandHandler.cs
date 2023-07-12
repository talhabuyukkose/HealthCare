using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Appointments;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Appointments
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, AppointmentDto>
    {
        private readonly ILogger<DeleteAppointmentCommandHandler> logger;
        private readonly IBaseRepository<Appointment> baseRepository;
        private readonly IMapper mapper;

        public DeleteAppointmentCommandHandler(ILogger<DeleteAppointmentCommandHandler> logger, IBaseRepository<Appointment> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<AppointmentDto> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var isExistAppointment = await baseRepository.AnyAsync(find => find.Id == request.Id);

            if (isExistAppointment)
            {
                logger.LogInformation($"{request.Id} value is not here");

                throw new ArgumentNullException(nameof(request), "Appointment.Id bulunamadı");
            }
            var appointment = await baseRepository.GetFindAsync(find => find.Id == request.Id);

            return mapper.Map<AppointmentDto>(appointment);
        }
    }
}
