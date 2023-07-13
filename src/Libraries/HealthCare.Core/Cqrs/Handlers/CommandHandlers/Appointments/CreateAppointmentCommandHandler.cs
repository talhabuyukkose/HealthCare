using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Appointments;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.CommandHandlers.Appointments
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentCommand>
    {
        private readonly ILogger<CreateAppointmentCommandHandler> logger;
        private readonly IBaseRepository<Appointment> repositoryAppointment;
        private readonly IBaseRepository<Hospital> repositoryHospital;
        private readonly IBaseRepository<MedicalUnit> repositoryMedicalUnit;
        private readonly IBaseRepository<Doctor> repositoryDoctor;
        private readonly IBaseRepository<Patient> repositoryPatient;
        private readonly IMapper mapper;

        public CreateAppointmentCommandHandler(
            ILogger<CreateAppointmentCommandHandler> logger,
            IBaseRepository<Appointment> repositoryAppointment,
            IBaseRepository<Hospital> repositoryHospital,
            IBaseRepository<MedicalUnit> repositoryMedicalUnit,
            IBaseRepository<Doctor> repositoryDoctor,
            IBaseRepository<Patient> repositoryPatient,
            IMapper mapper)
        {
            this.logger = logger;
            this.repositoryAppointment = repositoryAppointment;
            this.repositoryHospital = repositoryHospital;
            this.repositoryMedicalUnit = repositoryMedicalUnit;
            this.repositoryDoctor = repositoryDoctor;
            this.repositoryPatient = repositoryPatient;
            this.mapper = mapper;
        }
        public async Task<CreateAppointmentCommand> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await repositoryHospital.AnyAsync(any => any.Id == request.HospitalID) is false)
                    throw new Exception($"{nameof(request.HospitalID)} bulunamadı");

                if (await repositoryMedicalUnit.AnyAsync(any => any.Id == request.MedicalUnitID) is false)
                    throw new Exception($"{nameof(request.MedicalUnitID)} bulunamadı");

                if (await repositoryDoctor.AnyAsync(any => any.Id == request.DoctorID) is false)
                    throw new Exception($"{nameof(request.DoctorID)} bulunamadı");

                if (await repositoryPatient.AnyAsync(any => any.Id == request.PatientID) is false)
                    throw new Exception($"{nameof(request.PatientID)} bulunamadı");


                var appointment = mapper.Map<Appointment>(request);

                await repositoryAppointment.AddAsync(appointment);

                return request;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Create işlemi yapılamadı", ex);
            }
        }
    }
}
