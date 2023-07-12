using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Hospitals
{
    public class CreatePatientCommandHandler : IRequestHandler<CreateHospitalCommand, CreateHospitalCommand>
    {
        private readonly ILogger<CreatePatientCommandHandler> logger;
        private readonly IBaseRepository<Hospital> baseRepository;
        private readonly IMapper mapper;

        public CreatePatientCommandHandler(ILogger<CreatePatientCommandHandler> logger,IBaseRepository<Hospital> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<CreateHospitalCommand> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = mapper.Map<Hospital>(request);

            await baseRepository.AddAsync(hospital);

            return request;
        }
    }
}
