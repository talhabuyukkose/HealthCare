using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Doctors;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.DoctorsDto;


namespace HealthCare.Core.Mapper
{
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, DoctorIncludedDto>().ReverseMap();
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();
        }
    }
}
