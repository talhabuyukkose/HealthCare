using HealthCare.Core.Dto.Patients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Queries.Patients
{
    public class GetPatientsQuery : IRequest<ICollection<PatientDto>>
    {
    }
}
