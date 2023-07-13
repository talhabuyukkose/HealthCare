using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Patients;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.Patients;

namespace HealthCare.Core.Mapper
{
    public class PatientMapper : Profile
    {
        public PatientMapper()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Patient, PatientIncludedDto>().ReverseMap();
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
        }
    }
}
