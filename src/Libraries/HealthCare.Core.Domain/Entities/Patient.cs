using HealthCare.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Core.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        [MinLength(11)]
        [MaxLength(11)]
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
    }
}
