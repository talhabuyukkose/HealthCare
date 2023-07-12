using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Appointments;
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
    public class GetAppointmentIncludedQueryHandler : IRequestHandler<GetAppointmentIncludedQuery, ICollection<AppointmentIncludedDto>>
    {
        private readonly ILogger<GetAppointmentIncludedQueryHandler> logger;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;

        public GetAppointmentIncludedQueryHandler(ILogger<GetAppointmentIncludedQueryHandler> logger,IAppointmentRepository appointmentRepository,IMapper mapper)
        {
            this.logger = logger;
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
        }
        public async Task<ICollection<AppointmentIncludedDto>> Handle(GetAppointmentIncludedQuery request, CancellationToken cancellationToken)
        {
            var repo = await appointmentRepository.GetIncludedAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(appointmentRepository)} is turn null or empty");
                throw new ArgumentException("Randevu listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<AppointmentIncludedDto>>(repo);

            return _mapper;
        }
    }
}
