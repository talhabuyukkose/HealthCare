using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Patients;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Patients
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientCommand>
    {
        private readonly ILogger<UpdatePatientCommandHandler> logger;
        private readonly IBaseRepository<Patient> baseRepository;
        private readonly IMapper mapper;

        public UpdatePatientCommandHandler(ILogger<UpdatePatientCommandHandler> logger, IBaseRepository<Patient> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<UpdatePatientCommand> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await baseRepository.AnyAsync(any => any.Id == request.Id) is false)
                    throw new Exception($"{request.Id} bulunamadı");

                var patient = mapper.Map<Patient>(request);

                await baseRepository.UpdateAsync(patient);

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Update işlemi yapılamadı", ex);
            }
        }
    }
}
