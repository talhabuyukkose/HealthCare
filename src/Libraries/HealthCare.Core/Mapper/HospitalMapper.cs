using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.HospitalsDto;

namespace HealthCare.Core.Mapper
{
    public class HospitalMapper:Profile
    {
        public HospitalMapper()
        {
            CreateMap<Hospital,HospitalDto>().ReverseMap();
            CreateMap<HospitalIncludedDto, Hospital>().ReverseMap()
                .ForMember(item1 => item1.MedicalUnits, item2 => item2.MapFrom(ol => ol.HospitalMedicalUnits.Select(s => s.MedicalUnit)));
            CreateMap<Hospital,CreateHospitalCommand>().ReverseMap();
            CreateMap<Hospital,UpdateHospitalCommand>().ReverseMap();
        }
    }
}
