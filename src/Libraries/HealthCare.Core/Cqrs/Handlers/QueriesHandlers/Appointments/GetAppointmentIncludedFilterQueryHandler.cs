using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Appointments;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Interfaces.Cache;
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
    public class GetAppointmentIncludedFilterQueryHandler : IRequestHandler<GetAppointmentIncludedFilterQuery, ICollection<AppointmentIncludedDto>>
    {
        private readonly ILogger<GetAppointmentIncludedFilterQueryHandler> logger;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;
        private readonly IMemoryService memoryService;

        public GetAppointmentIncludedFilterQueryHandler(ILogger<GetAppointmentIncludedFilterQueryHandler> logger, IAppointmentRepository appointmentRepository, IMapper mapper, IMemoryService memoryService)
        {
            this.logger = logger;
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
            this.memoryService = memoryService;
        }
        public async Task<ICollection<AppointmentIncludedDto>> Handle(GetAppointmentIncludedFilterQuery request, CancellationToken cancellationToken)
        {
            var count = appointmentRepository.CountAsync();

            if (memoryService.TryGetValue(nameof(GetAppointmentIncludedFilterQuery) + "Count", out object objectcount))
            {
                if (count != objectcount)
                {
                    memoryService.Remove(nameof(GetAppointmentIncludedFilterQuery) + "Count");
                    memoryService.Remove(nameof(GetAppointmentIncludedFilterQuery));
                }
            }

            if (memoryService.TryGetValue(nameof(GetAppointmentIncludedFilterQuery), out object memoryData))
            {
                return mapper.Map<ICollection<AppointmentIncludedDto>>(memoryData);
            }

            var repo = await appointmentRepository.GetListWithFilterIncludedAsync(filter => filter.AppointmentDate.Day == request.dateTime.Day);

            if (repo == null)
            {
                logger.LogError($"{nameof(appointmentRepository)} is turn null or empty");
                throw new ArgumentException("Randevu listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<AppointmentIncludedDto>>(repo);

            memoryService.CreateEntry(nameof(GetAppointmentIncludedFilterQuery));
            memoryService.Set(nameof(GetAppointmentIncludedFilterQuery), _mapper, TimeSpan.FromHours(1));

            return _mapper;
        }
    }
}
