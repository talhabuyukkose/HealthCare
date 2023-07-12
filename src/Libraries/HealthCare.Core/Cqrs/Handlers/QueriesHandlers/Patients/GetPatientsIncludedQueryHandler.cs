using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Patients;
using HealthCare.Core.Dto.Patients;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Patients
{
    public class GetPatientsIncludedQueryHandler : IRequestHandler<GetPatientsIncludedQuery, ICollection<PatientIncludedDto>>
    {
        private readonly ILogger<GetPatientsIncludedQueryHandler> logger;
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;

        public GetPatientsIncludedQueryHandler(ILogger<GetPatientsIncludedQueryHandler> logger,IPatientRepository patientRepository,IMapper mapper)
        {
            this.logger = logger;
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<PatientIncludedDto>> Handle(GetPatientsIncludedQuery request, CancellationToken cancellationToken)
        {
            var repoPatients = await patientRepository.GetIncludedAsync();

            if (repoPatients == null)
            {
                logger.LogError($"{nameof(patientRepository)} is turn null or empty");
                throw new ArgumentException("Hasta listesi veritabanından getirilemedi");
            }

            var mapperpatients = mapper.Map<ICollection<PatientIncludedDto>>(repoPatients);

            return mapperpatients;
        }
    }
}
