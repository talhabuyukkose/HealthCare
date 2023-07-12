using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Diseases;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.DiseasesDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Diseases
{
    public class UpdateDiseaseCommandHandler : IRequestHandler<UpdateDiseaseCommand, UpdateDiseaseCommand>
    {
        private readonly ILogger<UpdateDiseaseCommandHandler> logger;
        private readonly IBaseRepository<Disease> baseRepository;
        private readonly IMapper mapper;

        public UpdateDiseaseCommandHandler(ILogger<UpdateDiseaseCommandHandler> logger, IBaseRepository<Disease> baseRepository, IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<UpdateDiseaseCommand> Handle(UpdateDiseaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await baseRepository.AnyAsync(any => any.Id == request.Id) is false)
                    throw new Exception($"{request.Id} bulunamadı");

                var disease = mapper.Map<Disease>(request);

                await baseRepository.UpdateAsync(disease);

                return request;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Update işlemi yapılamadı", ex);
            }
        }
    }
}
