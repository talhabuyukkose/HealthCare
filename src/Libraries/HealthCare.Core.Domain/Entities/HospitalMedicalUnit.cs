using HealthCare.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domain.Entities
{
    public class HospitalMedicalUnit : BaseEntity
    {
        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
        public int MedicalUnitID { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
    }
}
