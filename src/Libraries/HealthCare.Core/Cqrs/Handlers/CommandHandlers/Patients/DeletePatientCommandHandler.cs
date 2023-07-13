using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Patients;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.Patients;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Patients
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, PatientDto>
    {
        private readonly ILogger<DeletePatientCommandHandler> logger;
        private readonly IBaseRepository<Patient> baseRepository;
        private readonly IMapper mapper;

        public DeletePatientCommandHandler(ILogger<DeletePatientCommandHandler> logger, IBaseRepository<Patient> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<PatientDto> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {

            if (await baseRepository.AnyAsync(find => find.Id == request.Id) is false)
            {
                logger.LogInformation($"{request.Id} value is not here");

                throw new ArgumentNullException(nameof(request), "Patient.Id bulunamadı");
            }
            var patient = await baseRepository.GetFindAsync(find => find.Id == request.Id);

            return mapper.Map<PatientDto>(patient);
        }
    }
}
