using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Dto.MedicalUnitsDto
{
    public class MedicalUnitIncludedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
