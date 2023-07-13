using HealthCare.Core.Dto.MedicalUnitsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Queries.MedicalUnits
{
    public class GetMedicalUnitsQuery:IRequest<ICollection<MedicalUnitDto>>
    {
    }
}
