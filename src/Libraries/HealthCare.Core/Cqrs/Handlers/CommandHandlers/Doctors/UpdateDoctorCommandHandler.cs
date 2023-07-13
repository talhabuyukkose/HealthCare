using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Doctors;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Doctors
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdateDoctorCommand>
    {
        private readonly ILogger<UpdateDoctorCommandHandler> logger;
        private readonly IBaseRepository<Doctor> repositoryDoctor;
        private readonly IBaseRepository<MedicalUnit> repositoryMedicalUnit;
        private readonly IBaseRepository<Hospital> repositoryHospital;
        private readonly IMapper mapper;

        public UpdateDoctorCommandHandler(
            ILogger<UpdateDoctorCommandHandler> logger,
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
        public async Task<UpdateDoctorCommand> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await repositoryMedicalUnit.AnyAsync(any => any.Id == request.MedicalUnitID))
                    throw new Exception($"{nameof(request.MedicalUnitID)} bulunamadı");

                if (await repositoryHospital.AnyAsync(any => any.Id == request.HospitalID))
                    throw new Exception($"{nameof(request.HospitalID)} bulunamadı");


                if (await repositoryDoctor.AnyAsync(any => any.Id == request.Id) is false)
                    throw new Exception($"{request.Id} bulunamadı");

                var doctor = mapper.Map<Doctor>(request);

                await repositoryDoctor.UpdateAsync(doctor);

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Update işlemi yapılamadı", ex);
            }
        }
    }
}
