using HealthCare.Core.Dto.DoctorsDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Queries.Doctors
{
    public class GetDoctorsIncludedQuery : IRequest<ICollection<DoctorIncludedDto>>
    {
    }
}
