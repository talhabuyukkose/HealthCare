using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Hospitals
{
    public class DeleteHospitalCommandHandler : IRequestHandler<DeleteHospitalCommand, HospitalDto>
    {
        private readonly ILogger<DeleteHospitalCommandHandler> logger;
        private readonly IBaseRepository<Hospital> baseRepository;
        private readonly IMapper mapper;

        public DeleteHospitalCommandHandler(ILogger<DeleteHospitalCommandHandler> logger, IBaseRepository<Hospital> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<HospitalDto> Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
        {
            if (await baseRepository.AnyAsync(find => find.Id == request.Id) is false)
            {
                logger.LogInformation($"{request.Id} value is not here");

                throw new ArgumentNullException(nameof(request), "Hospital.Id bulunamadı");
            }
            var hospital = await baseRepository.GetFindAsync(find => find.Id == request.Id);

            return mapper.Map<HospitalDto>(hospital);
        }
    }
}
