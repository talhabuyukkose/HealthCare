using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Hospitals;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Dto.Patients;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Hospitals
{
    public class GetHospitalsQueryHandler : IRequestHandler<GetHospitalsQuery, ICollection<HospitalDto>>
    {
        private readonly ILogger<GetHospitalsQueryHandler> logger;
        private readonly IBaseRepository<Hospital> baseRepository;
        private readonly IMapper mapper;

        public GetHospitalsQueryHandler(ILogger<GetHospitalsQueryHandler> logger,IBaseRepository<Hospital> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<HospitalDto>> Handle(GetHospitalsQuery request, CancellationToken cancellationToken)
        {
            var repo = await baseRepository.GetAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(baseRepository)} is turn null or empty");
                throw new ArgumentException("Hasta listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<HospitalDto>>(repo);

            return _mapper;
        }
    }
}
