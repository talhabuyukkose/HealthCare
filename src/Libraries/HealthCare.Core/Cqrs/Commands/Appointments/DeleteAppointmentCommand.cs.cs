using HealthCare.Core.Dto.AppointmentsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Appointments
{
    public class DeleteAppointmentCommand : IRequest<AppointmentDto>
    {
        public int Id { get; set; }
    }
}
