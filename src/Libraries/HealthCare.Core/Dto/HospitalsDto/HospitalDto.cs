using HealthCare.Core.Domain.Enums;

namespace HealthCare.Core.Dto.HospitalsDto
{
    public class HospitalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
