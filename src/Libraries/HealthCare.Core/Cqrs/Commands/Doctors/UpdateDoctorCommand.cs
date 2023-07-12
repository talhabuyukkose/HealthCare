using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Doctors
{
    public class UpdateDoctorCommand : IRequest<UpdateDoctorCommand>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int MedicalUnitID { get; set; }
        public int HospitalID { get; set; }
    }
}
