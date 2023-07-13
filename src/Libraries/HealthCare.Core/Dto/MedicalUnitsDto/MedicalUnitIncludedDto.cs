using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Domain.Enums;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Dto.DoctorsDto;
using HealthCare.Core.Dto.HospitalsDto;

namespace HealthCare.Core.Dto.MedicalUnitsDto
{
    public class MedicalUnitIncludedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HospitalDto> Hospitals { get; set; }
        public ICollection<DoctorDto> Doctors { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
