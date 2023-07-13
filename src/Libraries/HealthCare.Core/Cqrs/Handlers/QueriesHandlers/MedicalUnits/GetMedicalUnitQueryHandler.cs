using AutoMapper;
using HealthCare.Core.Cqrs.Queries.MedicalUnits;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.MedicalUnitsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.MedicalUnits
{
    public class GetMedicalUnitQueryHandler : IRequestHandler<GetMedicalUnitsQuery, ICollection<MedicalUnitDto>>
    {
        private readonly ILogger<GetMedicalUnitQueryHandler> logger;
        private readonly IBaseRepository<MedicalUnit> baseRepository;
        private readonly IMapper mapper;

        public GetMedicalUnitQueryHandler(ILogger<GetMedicalUnitQueryHandler> logger, IBaseRepository<MedicalUnit> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<MedicalUnitDto>> Handle(GetMedicalUnitsQuery request, CancellationToken cancellationToken)
        {
            var repo = await baseRepository.GetListAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(baseRepository)} is turn null or empty");
                throw new ArgumentException("Birim listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<MedicalUnitDto>>(repo);

            return _mapper;
        }
    }
}
