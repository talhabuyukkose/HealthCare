using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Doctors;
using HealthCare.Core.Dto.DoctorsDto;
using HealthCare.Core.Dto.MedicalUnitsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Doctors
{
    public class GetDoctorsIncludedQueryHandler : IRequestHandler<GetDoctorsIncludedQuery, ICollection<DoctorIncludedDto>>
    {
        private readonly ILogger<GetDoctorsIncludedQueryHandler> logger;
        private readonly IDoctorRepository doctorRepository;
        private readonly IMapper mapper;

        public GetDoctorsIncludedQueryHandler(ILogger<GetDoctorsIncludedQueryHandler> logger,IDoctorRepository doctorRepository,IMapper mapper)
        {
            this.logger = logger;
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<DoctorIncludedDto>> Handle(GetDoctorsIncludedQuery request, CancellationToken cancellationToken)
        {
            var repo = await doctorRepository.GetIncludedAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(doctorRepository)} is turn null or empty");
                throw new ArgumentException("Doktor listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<DoctorIncludedDto>>(repo);

            return _mapper;
        }
    }
}
