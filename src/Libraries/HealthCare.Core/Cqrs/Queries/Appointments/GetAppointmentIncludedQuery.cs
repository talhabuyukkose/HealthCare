using HealthCare.Core.Dto.AppointmentsDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Queries.Appointments
{
    public class GetAppointmentIncludedQuery : IRequest<ICollection<AppointmentIncludedDto>>
    {
    }
}
