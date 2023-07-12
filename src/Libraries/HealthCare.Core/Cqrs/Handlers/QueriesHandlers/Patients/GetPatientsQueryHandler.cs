using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Patients;
using HealthCare.Core.Dto.Patients;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HealthCare.Core.Dto.DiseasesDto;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Patients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, ICollection<PatientDto>>
    {
        private readonly ILogger<GetPatientsQueryHandler> logger;
        private readonly IBaseRepository<Patient> baseRepository;
        private readonly IMapper mapper;

        public GetPatientsQueryHandler(ILogger<GetPatientsQueryHandler> logger, IBaseRepository<Patient> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<ICollection<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var repo = await baseRepository.GetAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(baseRepository)} is turn null or empty");
                throw new ArgumentException("Hasta listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<PatientDto>>(repo);

            return _mapper;

        }
    }
}
