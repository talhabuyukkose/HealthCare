using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Dto.HospitalsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Mapper
{
    public class HospitalMapper:Profile
    {
        public HospitalMapper()
        {
            CreateMap<Hospital,HospitalDto>().ReverseMap();
            CreateMap<Hospital,HospitalIncludedDto>().ReverseMap();
            CreateMap<Hospital,CreateHospitalCommand>().ReverseMap();
            CreateMap<Hospital,UpdateHospitalCommand>().ReverseMap();
        }
    }
}
