using MediatR;

namespace HealthCare.Core.Cqrs.Commands.MedicalUnits
{
    public class UpdateMedicalUnitCommand : IRequest<UpdateMedicalUnitCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
