using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Appointments;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Dto.DoctorsDto;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Appointments
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, ICollection<AppointmentDto>>
    {
        private readonly ILogger<GetAppointmentQueryHandler> logger;
        private readonly IBaseRepository<Appointment> baseRepository;
        private readonly IMapper mapper;

        public GetAppointmentQueryHandler(ILogger<GetAppointmentQueryHandler> logger,IBaseRepository<Appointment> baseRepository,IMapper mapper)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<AppointmentDto>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var repo = await baseRepository.GetAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(baseRepository)} is turn null or empty");
                throw new ArgumentException("Randevu listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<AppointmentDto>>(repo);

            return _mapper;
        }
    }
}
