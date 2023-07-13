using HealthCare.Core.Domain.Enums;

namespace HealthCare.Core.Dto.DoctorsDto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
