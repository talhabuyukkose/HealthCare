using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Hospitals
{
    public class UpdateHospitalCommand : IRequest<UpdateHospitalCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
