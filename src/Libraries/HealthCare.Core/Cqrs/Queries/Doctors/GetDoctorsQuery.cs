using HealthCare.Core.Dto.DoctorsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Queries.Doctors
{
    public class GetDoctorsQuery : IRequest<ICollection<DoctorDto>>
    {
    }
}
