using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Doctors;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Doctors
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorCommand>
    {
        private readonly ILogger<CreateDoctorCommandHandler> logger;
        private readonly IBaseRepository<Doctor> repositoryDoctor;
        private readonly IBaseRepository<MedicalUnit> repositoryMedicalUnit;
        private readonly IBaseRepository<Hospital> repositoryHospital;
        private readonly IMapper mapper;

        public CreateDoctorCommandHandler(
            ILogger<CreateDoctorCommandHandler> logger,
            IBaseRepository<Doctor> repositoryDoctor,
            IBaseRepository<MedicalUnit> repositoryMedicalUnit,
            IBaseRepository<Hospital> repositoryHospital,
            IMapper mapper)
        {
            this.logger = logger;
            this.repositoryDoctor = repositoryDoctor;
            this.repositoryMedicalUnit = repositoryMedicalUnit;
            this.repositoryHospital = repositoryHospital;
            this.mapper = mapper;
        }
        public async Task<CreateDoctorCommand> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await repositoryMedicalUnit.AnyAsync(any => any.Id == request.MedicalUnitID) is false)
                    throw new Exception($"{nameof(request.MedicalUnitID)} bulunamadı");

                if (await repositoryHospital.AnyAsync(any => any.Id == request.HospitalID) is false)
                    throw new Exception($"{nameof(request.HospitalID)} bulunamadı");

                var doctor = mapper.Map<Doctor>(request);

                await repositoryDoctor.AddAsync(doctor);

                return request;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Create işlemi yapılamadı", ex);
            }
        }
    }
}
