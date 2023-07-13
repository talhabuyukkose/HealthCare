using HealthCare.Core.Cqrs.Commands.MedicalUnits;
using HealthCare.Core.Cqrs.Queries.MedicalUnits;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalUnitController : ControllerBase
    {
        private readonly ILogger<MedicalUnitController> logger;
        private readonly IMediator mediator;

        public MedicalUnitController(ILogger<MedicalUnitController> logger,IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool IsIncluded)
        {
            switch (IsIncluded)
            {
                case true:
                    var queryIncluded = new GetMedicalUnitsIncludedQuery();

                    var responseIncluded = await mediator.Send(queryIncluded);

                    return Ok(responseIncluded);
                case false:
                    var query = new GetMedicalUnitsQuery();

                    var response = await mediator.Send(query);

                    return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMedicalUnitCommand patientCommand)
        {
            return Ok(await mediator.Send(patientCommand));
        }
        [HttpPost("Array")]
        public async Task<IActionResult> Post(CreateMedicalUnitsCommand patientCommand)
        {
            return Ok(await mediator.Send(patientCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateMedicalUnitCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteMedicalUnitCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
