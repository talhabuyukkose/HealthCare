using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Appointments;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Interfaces.Cache;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Appointments
{
    public class GetAppointmentIncludedQueryHandler : IRequestHandler<GetAppointmentIncludedQuery, ICollection<AppointmentIncludedDto>>
    {
        private readonly ILogger<GetAppointmentIncludedQueryHandler> logger;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;
        private readonly IMemoryService memoryService;

        public GetAppointmentIncludedQueryHandler(ILogger<GetAppointmentIncludedQueryHandler> logger, IAppointmentRepository appointmentRepository, IMapper mapper, IMemoryService memoryService)
        {
            this.logger = logger;
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
            this.memoryService = memoryService;
        }
        public async Task<ICollection<AppointmentIncludedDto>> Handle(GetAppointmentIncludedQuery request, CancellationToken cancellationToken)
        {
            var count = await appointmentRepository.CountAsync();

            if (memoryService.TryGetValue(nameof(GetAppointmentIncludedQuery) + "Count", out object objectcount))
            {

                if (count != Convert.ToInt32(objectcount))
                {
                    memoryService.Remove(nameof(GetAppointmentIncludedQuery) + "Count");
                    memoryService.Remove(nameof(GetAppointmentIncludedQuery));
                }
            }

            if (memoryService.TryGetValue(nameof(GetAppointmentIncludedQuery), out object memoryData))
            {
                return mapper.Map<ICollection<AppointmentIncludedDto>>(memoryData);
            }
            var repo = await appointmentRepository.GetListIncludedAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(appointmentRepository)} is turn null or empty");
                throw new ArgumentException("Randevu listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<AppointmentIncludedDto>>(repo);

            memoryService.CreateEntry(nameof(GetAppointmentIncludedQuery));
            memoryService.Set(nameof(GetAppointmentIncludedQuery), _mapper, TimeSpan.FromHours(1));

            memoryService.CreateEntry(nameof(GetAppointmentIncludedQuery) + "Count");
            memoryService.Set(nameof(GetAppointmentIncludedQuery) + "Count", _mapper.Count(), TimeSpan.FromHours(1));

            return _mapper;
        }
    }
}
