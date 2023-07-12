using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Diseases;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Diseases
{
    public class CreateDiseaseCommandHandler : IRequestHandler<CreateDiseaseCommand, CreateDiseaseCommand>
    {
        private readonly ILogger<CreateDiseaseCommandHandler> logger;
        private readonly IBaseRepository<Disease> baseRepository;
        private readonly IMapper mapper;

        public CreateDiseaseCommandHandler(ILogger<CreateDiseaseCommandHandler> logger, IBaseRepository<Disease> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<CreateDiseaseCommand> Handle(CreateDiseaseCommand request, CancellationToken cancellationToken)
        {
            var disease = mapper.Map<Disease>(request);

            await baseRepository.AddAsync(disease);

            return request;
        }
    }
}
