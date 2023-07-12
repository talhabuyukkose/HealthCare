using HealthCare.Core.Dto.DiseasesDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Commands.Diseases
{
    public class DeleteDiseaseCommand:IRequest<DiseaseDto>
    {
        public int Id { get; set; }
    }
}
