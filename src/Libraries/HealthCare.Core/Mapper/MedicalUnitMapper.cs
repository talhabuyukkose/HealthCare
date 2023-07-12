using AutoMapper;
using HealthCare.Core.Cqrs.Commands.MedicalUnits;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.MedicalUnitsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Mapper
{
    public class MedicalUnitMapper:Profile
    {
        public MedicalUnitMapper()
        {
            CreateMap<MedicalUnit, MedicalUnitDto>().ReverseMap();
            CreateMap<MedicalUnit,MedicalUnitIncludedDto>().ReverseMap();
            CreateMap<MedicalUnit,CreateMedicalUnitCommand>().ReverseMap();
            CreateMap<MedicalUnit,UpdateMedicalUnitCommand>().ReverseMap();
        }
    }
}
