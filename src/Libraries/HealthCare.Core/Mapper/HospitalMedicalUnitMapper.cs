using AutoMapper;
using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Mapper
{
    public class HospitalMedicalUnitMapper : Profile
    {
        public HospitalMedicalUnitMapper()
        {
            CreateMap<HospitalMedicalUnit,AddMedicalUnitCommand>().ReverseMap();
        }
    }
}
