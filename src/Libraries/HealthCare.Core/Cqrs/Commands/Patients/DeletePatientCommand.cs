using HealthCare.Core.Dto.Patients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Commands.Patients
{
    public class DeletePatientCommand : IRequest<PatientDto>
    {
        public int Id { get; set; }
    }
}
