using HealthCare.Core.Domain.Enums;

namespace HealthCare.Core.Dto.MedicalUnitsDto
{
    public class MedicalUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
