using HealthCare.Core.Dto.MedicalUnitsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Queries.MedicalUnits
{
    public class GetMedicalUnitsIncludedQuery : IRequest<ICollection<MedicalUnitIncludedDto>>
    {
    }
}
