using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Hospitals
{
    public class UpdateHospitalCommandHandler : IRequestHandler<UpdateHospitalCommand, UpdateHospitalCommand>
    {
        private readonly ILogger<UpdateHospitalCommandHandler> logger;
        private readonly IBaseRepository<Hospital> baseRepository;
        private readonly IMapper mapper;

        public UpdateHospitalCommandHandler(ILogger<UpdateHospitalCommandHandler> logger,IBaseRepository<Hospital> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<UpdateHospitalCommand> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await baseRepository.AnyAsync(any => any.Id == request.Id) is false)
                    throw new Exception($"{request.Id} bulunamadı");

                var hospital = mapper.Map<Hospital>(request);

                await baseRepository.UpdateAsync(hospital);

                return request;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Update işlemi yapılamadı", ex);
            }
        }
    }
}
