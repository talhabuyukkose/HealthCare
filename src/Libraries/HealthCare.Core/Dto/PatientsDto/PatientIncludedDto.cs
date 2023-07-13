using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Domain.Enums;

namespace HealthCare.Core.Dto.Patients
{
    public class PatientIncludedDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsSendEmail { get; set; }
        public bool IsSendSms { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
