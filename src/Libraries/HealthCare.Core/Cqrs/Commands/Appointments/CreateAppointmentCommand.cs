using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Appointments
{
    public class CreateAppointmentCommand : IRequest<CreateAppointmentCommand>
    {
        public DateTime AppointmentDate { get; set; }
        public int HospitalID { get; set; }
        public int MedicalUnitID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
    }
}
