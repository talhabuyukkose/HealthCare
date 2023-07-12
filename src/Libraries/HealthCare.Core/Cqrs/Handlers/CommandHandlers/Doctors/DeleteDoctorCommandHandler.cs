using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Doctors;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.DoctorsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Doctors
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, DoctorDto>
    {
        private readonly ILogger<DeleteDoctorCommandHandler> logger;
        private readonly IBaseRepository<Doctor> baseRepository;
        private readonly IMapper mapper;

        public DeleteDoctorCommandHandler(ILogger<DeleteDoctorCommandHandler> logger,IBaseRepository<Doctor> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<DoctorDto> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var isExistDoctor = await baseRepository.AnyAsync(find => find.Id == request.Id);

            if (isExistDoctor)
            {
                logger.LogInformation($"{request.Id} value is not here");

                throw new ArgumentNullException(nameof(request), "Doctor.Id bulunamadı");
            }
            var doctor = await baseRepository.GetFindAsync(find => find.Id == request.Id);

            return mapper.Map<DoctorDto>(doctor);
        }
    }
}
