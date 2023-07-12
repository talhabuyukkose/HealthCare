using HealthCare.Core.Dto.DiseasesDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Queries.Diseases
{
    public class GetDiseasesIncludedQuery : IRequest<ICollection<DiseaseIncludedDto>>
    {
    }
}
