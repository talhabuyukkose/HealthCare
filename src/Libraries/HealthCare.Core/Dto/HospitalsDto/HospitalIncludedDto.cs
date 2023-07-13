using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Domain.Enums;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Dto.DoctorsDto;
using HealthCare.Core.Dto.MedicalUnitsDto;

namespace HealthCare.Core.Dto.HospitalsDto
{
    public class HospitalIncludedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<DoctorDto> Doctors { get; set; }
        public ICollection<MedicalUnitDto> MedicalUnits { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
