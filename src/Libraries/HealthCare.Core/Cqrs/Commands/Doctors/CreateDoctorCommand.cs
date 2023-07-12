using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Doctors
{
    public class CreateDoctorCommand : IRequest<CreateDoctorCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int MedicalUnitID { get; set; }
        public int HospitalID { get; set; }
    }
}
