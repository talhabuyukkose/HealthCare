using HealthCare.Core.Dto.DoctorsDto;
using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Doctors
{
    public class DeleteDoctorCommand : IRequest<DoctorDto>
    {
        public int Id { get; set; }
    }
}
