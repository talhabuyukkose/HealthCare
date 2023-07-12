using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Hospitals;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Hospitals
{
    public class GetHospitalsIncludedQueryHandler : IRequestHandler<GetHospitalsIncludedQuery, ICollection<HospitalIncludedDto>>
    {
        private readonly ILogger<GetHospitalsIncludedQueryHandler> logger;
        private readonly IHospitalRepository hospitalRepository;
        private readonly IMapper mapper;

        public GetHospitalsIncludedQueryHandler(ILogger<GetHospitalsIncludedQueryHandler> logger,IHospitalRepository hospitalRepository,IMapper mapper)
        {
            this.logger = logger;
            this.hospitalRepository = hospitalRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<HospitalIncludedDto>> Handle(GetHospitalsIncludedQuery request, CancellationToken cancellationToken)
        {
            var repohospitals = await hospitalRepository.GetIncludedAsync();

            if (repohospitals == null)
            {
                logger.LogError($"{nameof(hospitalRepository)} is turn null or empty");
                throw new ArgumentException("Hasta listesi veritabanından getirilemedi");
            }

            var mapperHospitals = mapper.Map<ICollection<HospitalIncludedDto>>(repohospitals);

            return mapperHospitals;
        }
    }
}
