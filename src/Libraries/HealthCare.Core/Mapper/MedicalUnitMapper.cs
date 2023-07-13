using AutoMapper;
using HealthCare.Core.Cqrs.Commands.MedicalUnits;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Dto.MedicalUnitsDto;


namespace HealthCare.Core.Mapper
{
    public class MedicalUnitMapper : Profile
    {
        public MedicalUnitMapper()
        {
            CreateMap<MedicalUnit, MedicalUnitDto>().ReverseMap();
            CreateMap<MedicalUnitIncludedDto, MedicalUnit>().ReverseMap()
                .ForMember(item1 => item1.Hospitals, item2 => item2.MapFrom(ol => ol.HospitalMedicalUnits.Select(s => s.Hospital)));
            CreateMap<MedicalUnit, CreateMedicalUnitCommand>().ReverseMap();
            CreateMap<MedicalUnit, UpdateMedicalUnitCommand>().ReverseMap();
        }
    }
}
