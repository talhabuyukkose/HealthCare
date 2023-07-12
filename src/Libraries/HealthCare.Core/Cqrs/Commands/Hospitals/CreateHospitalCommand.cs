using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Hospitals
{
    public class CreateHospitalCommand : IRequest<CreateHospitalCommand>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
