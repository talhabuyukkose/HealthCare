using AutoMapper;
using HealthCare.Core.Cqrs.Queries.Appointments;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Interfaces.Cache;
using HealthCare.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HealthCare.Core.Cqrs.Handlers.QueriesHandlers.Appointments
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, ICollection<AppointmentDto>>
    {
        private readonly ILogger<GetAppointmentQueryHandler> logger;
        private readonly IBaseRepository<Appointment> baseRepository;
        private readonly IMapper mapper;
        private readonly IMemoryService memoryService;

        public GetAppointmentQueryHandler(ILogger<GetAppointmentQueryHandler> logger, IBaseRepository<Appointment> baseRepository, IMapper mapper,IMemoryService memoryService)
        {
            this.logger = logger;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.memoryService = memoryService;
        }
        public async Task<ICollection<AppointmentDto>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var count = await baseRepository.CountAsync();

            if (memoryService.TryGetValue(nameof(GetAppointmentQuery) + "Count", out object objectcount))
            {

                if (count != Convert.ToInt32(objectcount))
                {
                    memoryService.Remove(nameof(GetAppointmentQuery) + "Count");
                    memoryService.Remove(nameof(GetAppointmentQuery));
                }
            }

            if (memoryService.TryGetValue(nameof(GetAppointmentQuery), out object memoryData))
            {
                return mapper.Map<ICollection<AppointmentDto>>(memoryData);
            }
            var repo = await baseRepository.GetListAsync();

            if (repo == null)
            {
                logger.LogError($"{nameof(baseRepository)} is turn null or empty");
                throw new ArgumentException("Randevu listesi veritabanından getirilemedi");
            }

            var _mapper = mapper.Map<ICollection<AppointmentDto>>(repo);

            memoryService.CreateEntry(nameof(GetAppointmentQuery));
            memoryService.Set(nameof(GetAppointmentQuery), _mapper, TimeSpan.FromHours(1));

            memoryService.CreateEntry(nameof(GetAppointmentQuery) + "Count");
            memoryService.Set(nameof(GetAppointmentQuery) + "Count", _mapper.Count(), TimeSpan.FromHours(1));

            return _mapper;
        }
    }
}
