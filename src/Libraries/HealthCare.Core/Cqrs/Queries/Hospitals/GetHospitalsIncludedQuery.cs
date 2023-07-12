using HealthCare.Core.Dto.HospitalsDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Queries.Hospitals
{
    public class GetHospitalsIncludedQuery : IRequest<ICollection<HospitalIncludedDto>>
    {
    }
}
