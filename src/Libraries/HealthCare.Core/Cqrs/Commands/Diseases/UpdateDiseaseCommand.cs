using HealthCare.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Commands.Diseases
{
    public class UpdateDiseaseCommand:IRequest<UpdateDiseaseCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public short Level { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
