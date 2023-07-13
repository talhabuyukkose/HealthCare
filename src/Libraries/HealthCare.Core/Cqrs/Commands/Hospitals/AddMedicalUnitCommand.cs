using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Hospitals
{
    public class AddMedicalUnitCommand : IRequest<AddMedicalUnitCommand>
    {
        public int HospitalID { get; set; }
        public int MedicalUnitID { get; set; }
    }
}
