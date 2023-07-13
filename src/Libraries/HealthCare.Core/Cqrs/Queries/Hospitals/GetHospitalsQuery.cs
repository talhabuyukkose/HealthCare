using HealthCare.Core.Dto.HospitalsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Queries.Hospitals
{
    public class GetHospitalsQuery : IRequest<ICollection<HospitalDto>>
    {
    }
}
