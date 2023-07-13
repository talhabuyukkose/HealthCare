using HealthCare.Core.Dto.AppointmentsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Queries.Appointments
{
    public class GetAppointmentIncludedQuery : IRequest<ICollection<AppointmentIncludedDto>>
    {
    }
}
