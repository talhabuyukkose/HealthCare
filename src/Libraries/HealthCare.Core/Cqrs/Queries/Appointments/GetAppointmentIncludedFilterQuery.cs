using HealthCare.Core.Dto.AppointmentsDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Queries.Appointments
{
    public class GetAppointmentIncludedFilterQuery:IRequest<ICollection<AppointmentIncludedDto>>
    {
        public DateTime dateTime { get; set; }
    }
}
