using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Diseases;
using HealthCare.Core.Dto.DiseasesDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Diseases
{
    public class GetDiseasesIncludedQueryHandler : IRequestHandler<GetDiseasesIncludedQuery, ICollection<DiseaseIncludedDto>>
    {
        private readonly ILogger<GetDiseasesIncludedQueryHandler> logger;
        private readonly IDiseaseRepository diseaseRepository;
        private readonly IMapper mapper;

        public GetDiseasesIncludedQueryHandler(ILogger<GetDiseasesIncludedQueryHandler> logger, IDiseaseRepository diseaseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.diseaseRepository = diseaseRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<DiseaseIncludedDto>> Handle(GetDiseasesIncludedQuery request, CancellationToken cancellationToken)
        {
            var repoDiseases = await diseaseRepository.GetIncludedAsync();

            if (repoDiseases == null)
            {
                logger.LogError($"{nameof(diseaseRepository)} is turn null or empty");
                throw new ArgumentException("Hasta listesi veritabanından getirilemedi");
            }

            var mapperDiseases = mapper.Map<ICollection<DiseaseIncludedDto>>(repoDiseases);

            return mapperDiseases;
        }
    }
}
