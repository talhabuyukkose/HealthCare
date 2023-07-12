using HealthCare.Core.Dto.MedicalUnitsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Commands.MedicalUnits
{
    public class DeleteMedicalUnitCommand : IRequest<MedicalUnitDto>
    {
        public int Id { get; set; }
    }
}
