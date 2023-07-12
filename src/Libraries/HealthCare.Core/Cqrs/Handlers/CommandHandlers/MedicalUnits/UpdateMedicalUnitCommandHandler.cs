using AutoMapper;
using HealthCare.Core.Cqrs.Commands.MedicalUnits;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.MedicalUnits
{
    public class UpdateMedicalUnitCommandHandler : IRequestHandler<UpdateMedicalUnitCommand, UpdateMedicalUnitCommand>
    {
        private readonly ILogger<UpdateMedicalUnitCommandHandler> logger;
        private readonly IBaseRepository<MedicalUnit> baseRepository;
        private readonly IMapper mapper;

        public UpdateMedicalUnitCommandHandler(ILogger<UpdateMedicalUnitCommandHandler> logger,IBaseRepository<MedicalUnit> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<UpdateMedicalUnitCommand> Handle(UpdateMedicalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await baseRepository.AnyAsync(any => any.Id == request.Id) is false)
                    throw new Exception($"{request.Id} bulunamadı");

                var medicalUnit = mapper.Map<MedicalUnit>(request);

                await baseRepository.UpdateAsync(medicalUnit);

                return request;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Update işlemi yapılamadı", ex);
            }
        }
    }
}
