using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Diseases;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.DiseasesDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Diseases
{
    public class DeleteDiseaseCommandHandler : IRequestHandler<DeleteDiseaseCommand, DiseaseDto>
    {
        private readonly ILogger<DeleteDiseaseCommandHandler> logger;
        private readonly IBaseRepository<Disease> baseRepository;
        private readonly IMapper mapper;

        public DeleteDiseaseCommandHandler(ILogger<DeleteDiseaseCommandHandler> logger, IBaseRepository<Disease> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<DiseaseDto> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        {
            var IsExistDisease = await baseRepository.AnyAsync(find => find.Id == request.Id);

            if (IsExistDisease)
            {
                logger.LogInformation($"{request.Id} value is not here");

                throw new ArgumentNullException(nameof(request), "Disease.Id bulunamadı");
            }
            var disease = await baseRepository.GetFindAsync(find => find.Id == request.Id);

            var diseaseDto = mapper.Map<DiseaseDto>(disease);

            return diseaseDto;
        }
    }
}
