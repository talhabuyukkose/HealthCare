﻿using HealthCare.Core.Dto.MedicalUnitsDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Cqrs.Commands.MedicalUnits
{
    public class DeleteMedicalUnitCommand:IRequest<MedicalUnitDto>
    {
        public int Id { get; set; }
    }
}
