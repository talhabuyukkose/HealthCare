using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Patients;
using HealthCare.Core.Dto.Patients;
using HealthCare.Core.Exceptions;
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

        public GetPatientsIncludedQueryHandler(ILogger<GetPatientsIncludedQueryHandler> logger, IPatientRepository patientRepository, IMapper mapper)
        {
            this.logger = logger;
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<PatientIncludedDto>> Handle(GetPatientsIncludedQuery request, CancellationToken cancellationToken)
        {
            ICollection<PatientIncludedDto> patientIncludedDtos = new List<PatientIncludedDto>();

            var repoPatients = await patientRepository.GetListIncludedAsync();

            if (repoPatients == null)
            {
                logger.LogError($"{nameof(patientRepository)} is turn null or empty");
                throw new ArgumentException("Hasta listesi veritabanından getirilemedi");
            }

            patientIncludedDtos = mapper.Map<ICollection<PatientIncludedDto>>(repoPatients);
            
            return patientIncludedDtos;
        }
    }
}
