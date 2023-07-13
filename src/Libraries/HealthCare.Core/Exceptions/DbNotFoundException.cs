using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Exceptions
{
    public class DbNotFoundException : Exception
    {
        public DbNotFoundException(string? message) : base(message)
        {
        }
    }
}
