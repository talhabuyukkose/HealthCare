using MediatR;

namespace HealthCare.Core.Cqrs.Commands.MedicalUnits
{
    public class CreateMedicalUnitCommand : IRequest<CreateMedicalUnitCommand>
    {
        public string Name { get; set; }
    }
}
