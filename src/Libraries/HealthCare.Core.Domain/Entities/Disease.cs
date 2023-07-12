using HealthCare.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domain.Entities
{
    public class Disease : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public short Level { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
