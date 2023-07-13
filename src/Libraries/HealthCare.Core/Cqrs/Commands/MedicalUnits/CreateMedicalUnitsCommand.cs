using MediatR;

namespace HealthCare.Core.Cqrs.Commands.MedicalUnits
{
    public class CreateMedicalUnitsCommand : IRequest<CreateMedicalUnitsCommand>
    {
        public ICollection<CreateMedicalUnitCommand> Names { get; set; }
    }
}
