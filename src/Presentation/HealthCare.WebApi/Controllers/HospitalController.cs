using HealthCare.Core.Cqrs.Commands.Hospitals;
using HealthCare.Core.Cqrs.Queries.Hospitals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly ILogger<HospitalController> logger;
        private readonly IMediator mediator;

        public HospitalController(ILogger<HospitalController> logger, IMediator mediator)
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
                    var queryIncluded = new GetHospitalsIncludedQuery();

                    var responseIncluded = await mediator.Send(queryIncluded);

                    return Ok(responseIncluded);
                case false:
                    var query = new GetHospitalsQuery();

                    var response = await mediator.Send(query);

                    return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateHospitalCommand patientCommand)
        {
            return Ok(await mediator.Send(patientCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateHospitalCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost("AddMedicalUnit")]
        public async Task<IActionResult> AddMedicalUnit(AddMedicalUnitCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteHospitalCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
