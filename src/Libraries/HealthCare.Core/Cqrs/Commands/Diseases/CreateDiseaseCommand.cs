using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Diseases
{
    public class CreateDiseaseCommand : IRequest<CreateDiseaseCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public short Level { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
