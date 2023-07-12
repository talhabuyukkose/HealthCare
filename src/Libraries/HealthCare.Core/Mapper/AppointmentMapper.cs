using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Appointments;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.AppointmentsDto;

namespace HealthCare.Core.Mapper
{
    public class AppointmentMapper:Profile
    {
        public AppointmentMapper()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, AppointmentIncludedDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentCommand>().ReverseMap();
        }
    }
}
