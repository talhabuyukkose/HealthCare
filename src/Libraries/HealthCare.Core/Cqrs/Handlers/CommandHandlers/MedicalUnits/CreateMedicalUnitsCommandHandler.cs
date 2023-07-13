using AutoMapper;
using HealthCare.Core.Cqrs.Commands.MedicalUnits;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.MedicalUnits
{
    public class CreateMedicalUnitsCommandHandler :IRequestHandler<CreateMedicalUnitsCommand, CreateMedicalUnitsCommand>
    {
        private readonly ILogger<CreateMedicalUnitsCommandHandler> logger;
        private readonly IBaseRepository<MedicalUnit> baseRepository;
        private readonly IMapper mapper;

        public CreateMedicalUnitsCommandHandler(ILogger<CreateMedicalUnitsCommandHandler> logger, IBaseRepository<MedicalUnit> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<CreateMedicalUnitsCommand> Handle(CreateMedicalUnitsCommand requests, CancellationToken cancellationToken)
        {
            var medicalUnits = mapper.Map<ICollection<MedicalUnit>>(requests.Names);

            await baseRepository.AddRangeAsync(medicalUnits);

            return requests;
        }
    }
}
