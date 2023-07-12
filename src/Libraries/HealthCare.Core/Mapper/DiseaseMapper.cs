using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Diseases;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.DiseasesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Mapper
{
    public class DiseaseMapper : Profile
    {
        public DiseaseMapper()
        {
            CreateMap<Disease, DiseaseDto>().ReverseMap();
            CreateMap<Disease, DiseaseIncludedDto>().ReverseMap();
            CreateMap<Disease, CreateDiseaseCommand>().ReverseMap();
            CreateMap<Disease, UpdateDiseaseCommand>().ReverseMap();
        }
    }
}
