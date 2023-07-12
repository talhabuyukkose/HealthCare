using HealthCare.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domain.Entities
{
    public class MedicalUnit : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
