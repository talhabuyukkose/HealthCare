using AutoMapper;
using HealthCare.Core.Cqrs.Queries.MedicalUnits;
using HealthCare.Core.Dto.MedicalUnitsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.MedicalUnits
{
    public class GetMedicalUnitIncludedQueryHandler : IRequestHandler<GetMedicalUnitsIncludedQuery, ICollection<MedicalUnitIncludedDto>>
    {
        private readonly ILogger<GetMedicalUnitIncludedQueryHandler> logger;
        private readonly IMedicalUnitRepository medicalUnitRepository;
        private readonly IMapper mapper;

        public GetMedicalUnitIncludedQueryHandler(ILogger<GetMedicalUnitIncludedQueryHandler> logger, IMedicalUnitRepository medicalUnitRepository, IMapper mapper)
        {
            this.logger = logger;
            this.medicalUnitRepository = medicalUnitRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<MedicalUnitIncludedDto>> Handle(GetMedicalUnitsIncludedQuery request, CancellationToken cancellationToken)
        {
            var repo = await medicalUnitRepository.GetListIncludedAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(medicalUnitRepository)} is turn null or empty");
                throw new ArgumentException("Birim listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<MedicalUnitIncludedDto>>(repo);

            return _mapper;
        }
    }
}
