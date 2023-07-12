using HealthCare.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
        public int MedicalUnitID { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}
