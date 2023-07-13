using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Patients;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Patients
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientCommand>
    {
        private readonly ILogger<CreatePatientCommandHandler> logger;
        private readonly IBaseRepository<Patient> baseRepository;
        private readonly IMapper mapper;

        public CreatePatientCommandHandler(ILogger<CreatePatientCommandHandler> logger, IBaseRepository<Patient> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<CreatePatientCommand> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = mapper.Map<Patient>(request);

            await baseRepository.AddAsync(patient);

            return request;
        }
    }
}
