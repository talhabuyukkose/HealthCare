using HealthCare.Core.Dto.DiseasesDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Diseases
{
    public class DeleteDiseaseCommand : IRequest<DiseaseDto>
    {
        public int Id { get; set; }
    }
}
