using HealthCare.Core.Dto.Patients;
using MediatR;

namespace HealthCare.Core.Cqrs.Queries.Patients
{
    public class GetPatientsIncludedQuery : IRequest<ICollection<PatientIncludedDto>>
    {
    }
}
