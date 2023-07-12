using HealthCare.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domain.Entities
{
    public   class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<MedicalUnit> MedicalUnits { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
