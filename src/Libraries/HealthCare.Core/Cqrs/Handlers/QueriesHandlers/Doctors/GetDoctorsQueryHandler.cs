using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Doctors;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.DoctorsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Doctors
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, ICollection<DoctorDto>>
    {
        private readonly ILogger<GetDoctorsQueryHandler> logger;
        private readonly IBaseRepository<Doctor> baseRepository;
        private readonly IMapper mapper;

        public GetDoctorsQueryHandler(ILogger<GetDoctorsQueryHandler> logger,IBaseRepository<Doctor> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var repo = await baseRepository.GetListAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(baseRepository)} is turn null or empty");
                throw new ArgumentException("Doktor listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<DoctorDto>>(repo);

            return _mapper;
        }
    }
}
