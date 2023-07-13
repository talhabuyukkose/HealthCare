using AutoMapper;
using HealthCare.Core.Cqrs.Commands.MedicalUnits;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.MedicalUnits
{
    public class CreateMedicalUnitCommandHandler : IRequestHandler<CreateMedicalUnitCommand, CreateMedicalUnitCommand>
    {
        private readonly ILogger<CreateMedicalUnitCommandHandler> logger;
        private readonly IBaseRepository<MedicalUnit> baseRepository;
        private readonly IMapper mapper;

        public CreateMedicalUnitCommandHandler(ILogger<CreateMedicalUnitCommandHandler> logger, IBaseRepository<MedicalUnit> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<CreateMedicalUnitCommand> Handle(CreateMedicalUnitCommand request, CancellationToken cancellationToken)
        {
            var medicalUnit = mapper.Map<MedicalUnit>(request);

            await baseRepository.AddAsync(medicalUnit);

            return request;
        }
    }
}
