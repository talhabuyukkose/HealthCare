using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Hospitals
{

    public class AddMedicalUnitCommandHandler : IRequestHandler<AddMedicalUnitCommand, AddMedicalUnitCommand>
    {
        private readonly ILogger<AddMedicalUnitCommandHandler> logger;
        private readonly IBaseRepository<Hospital> repositoryHospital;
        private readonly IBaseRepository<MedicalUnit> repositoryMedicalUnit;
        private readonly IBaseRepository<HospitalMedicalUnit> repositoryHospitalMedicaLUnit;
        private readonly IBaseRepository<Hospital> baseRepository;
        private readonly IMapper mapper;

        public AddMedicalUnitCommandHandler(
            ILogger<AddMedicalUnitCommandHandler> logger,
            IBaseRepository<Hospital> repositoryHospital,
            IBaseRepository<MedicalUnit> repositoryMedicalUnit,
            IBaseRepository<HospitalMedicalUnit> repositoryHospitalMedicaLUnit,
            IMapper mapper)
        {
            this.logger = logger;
            this.repositoryHospital = repositoryHospital;
            this.repositoryMedicalUnit = repositoryMedicalUnit;
            this.repositoryHospitalMedicaLUnit = repositoryHospitalMedicaLUnit;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<AddMedicalUnitCommand> Handle(AddMedicalUnitCommand request, CancellationToken cancellationToken)
        {
            if (await repositoryMedicalUnit.AnyAsync(any => any.Id == request.MedicalUnitID) is false)
                throw new Exception($"{nameof(request.MedicalUnitID)} bulunamadı");

            if (await repositoryHospital.AnyAsync(any => any.Id == request.HospitalID) is false)
                throw new Exception($"{nameof(request.HospitalID)} bulunamadı");
            try
            {
                var _mapped = mapper.Map<HospitalMedicalUnit>(request);

                await repositoryHospitalMedicaLUnit.AddAsync(_mapped);

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Update işlemi yapılamadı", ex);
            }

        }
    }
}
