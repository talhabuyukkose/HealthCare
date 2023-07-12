using HealthCare.Core.Dto.HospitalsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Hospitals
{
    public class DeleteHospitalCommand : IRequest<HospitalDto>
    {
        public int Id { get; set; }
    }
}
