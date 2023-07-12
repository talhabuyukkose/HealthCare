using HealthCare.Core.Dto.Patients;
using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Patients
{
    public class DeletePatientCommand : IRequest<PatientDto>
    {
        public int Id { get; set; }
    }
}
