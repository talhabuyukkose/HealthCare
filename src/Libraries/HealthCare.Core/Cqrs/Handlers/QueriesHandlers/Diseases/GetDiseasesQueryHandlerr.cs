using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Diseases;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.DiseasesDto;
using HealthCare.Core.Dto.Patients;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Diseases
{
    public class GetDiseasesQueryHandlerr : IRequestHandler<GetDiseasesQuery, ICollection<DiseaseDto>>
    {
        private readonly ILogger<GetDiseasesQueryHandlerr> logger;
        private readonly IBaseRepository<Disease> baseRepository;
        private readonly IMapper mapper;

        public GetDiseasesQueryHandlerr(ILogger<GetDiseasesQueryHandlerr> logger,IBaseRepository<Disease> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<DiseaseDto>> Handle(GetDiseasesQuery request, CancellationToken cancellationToken)
        {
            var repo = await baseRepository.GetAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(baseRepository)} is turn null or empty");
                throw new ArgumentException("Hastalık listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<DiseaseDto>>(repo);

            return _mapper;
        }
    }
}
