using AutoMapper;
using HealthCare.Core.Cqrs.Commands.MedicalUnits;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.MedicalUnitsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.MedicalUnits
{
    public class DeleteMedicalUnitCommandHandler : IRequestHandler<DeleteMedicalUnitCommand, MedicalUnitDto>
    {
        private readonly ILogger<DeleteMedicalUnitCommandHandler> logger;
        private readonly IBaseRepository<MedicalUnit> baseRepository;
        private readonly IMapper mapper;

        public DeleteMedicalUnitCommandHandler(ILogger<DeleteMedicalUnitCommandHandler> logger, IBaseRepository<MedicalUnit> baseRepository, IMapper mapper)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<MedicalUnitDto> Handle(DeleteMedicalUnitCommand request, CancellationToken cancellationToken)
        {
            var isExistMedicalUnit = await baseRepository.AnyAsync(find => find.Id == request.Id);

            if (isExistMedicalUnit)
            {
                logger.LogInformation($"{request.Id} value is not here");

                throw new ArgumentNullException(nameof(request), "Disease.Id bulunamadı");
            }
            var medicalUnit = await baseRepository.GetFindAsync(find => find.Id == request.Id);

            var medicalUnitDto = mapper.Map<MedicalUnitDto>(medicalUnit);

            return medicalUnitDto;
        }
    }
}
