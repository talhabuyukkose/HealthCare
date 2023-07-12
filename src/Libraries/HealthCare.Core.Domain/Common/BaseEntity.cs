using HealthCare.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domain.Common
{
    /// <summary>
    /// This class can not create an instance
    /// </summary>
    public abstract class BaseEntity
    {
        private const int TurkeyTimeZone = 3;
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow.AddHours(TurkeyTimeZone);
            Status = Status.Inserted;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
