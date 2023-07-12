﻿using MediatR;

namespace HealthCare.Core.Cqrs.Commands.Appointments
{
    public class UpdateAppointmentCommand : IRequest<UpdateAppointmentCommand>
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int HospitalID { get; set; }
        public int MedicalUnitID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
    }
}
